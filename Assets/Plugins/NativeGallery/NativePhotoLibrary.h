// NativePhotoLibrary.h
#import <Foundation/Foundation.h>

@interface NativePhotoLibrary : NSObject

+ (NSArray *)getAllPhotos;

@end

// NativePhotoLibrary.m
#import "NativePhotoLibrary.h"
#import <Photos/Photos.h>

@implementation NativePhotoLibrary

+ (NSArray *)getAllPhotos {
    NSMutableArray *photoPaths = [NSMutableArray array];
    
    PHFetchResult *allPhotos = [PHAsset fetchAssetsWithMediaType:PHAssetMediaTypeImage options:nil];
    for (PHAsset *asset in allPhotos) {
        PHImageRequestOptions *options = [[PHImageRequestOptions alloc] init];
        options.synchronous = YES;
        [[PHImageManager defaultManager] requestImageDataForAsset:asset
                                                          options:options
                                                    resultHandler:^(NSData *imageData, NSString *dataUTI, UIImageOrientation orientation, NSDictionary *info) {
            NSURL *imageUrl = [info objectForKey:@"PHImageFileURLKey"];
            [photoPaths addObject:imageUrl.absoluteString];
        }];
    }
    
    return [photoPaths copy];
}

@end
