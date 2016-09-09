/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

#import <UIKit/UIKit.h>
#import "UnityAppController.h"

extern "C" void ezarUnitySetGraphicsDevice(void* device, int deviceType, int eventType);
extern "C" void ezarUnityRenderEvent(int marker);

@interface EasyARAppController : UnityAppController
{
}
- (void)shouldAttachRenderDelegate;
@end

@implementation EasyARAppController

- (void)shouldAttachRenderDelegate;
{
	UnityRegisterRenderingPlugin(&ezarUnitySetGraphicsDevice, &ezarUnityRenderEvent);
}
@end


IMPL_APP_CONTROLLER_SUBCLASS(EasyARAppController)

