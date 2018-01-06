//
//  HideUnity.m
//  NativeUnity
//
//  Created by Shaw Walters on 8/25/16.
//  Copyright © 2016 Shaw Walters. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "AppDelegate.h"

@interface MyUnityPlugin:NSObject
/* method declaration */
+ (BOOL)hideUnityWindow;
@end

@implementation MyUnityPlugin

+ (BOOL)hideUnityWindow {
    
    AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
    [appDel hideUnityWindow];
    
    return true;
}
@end

//C-wrapper that Unity communicates with
extern "C"
{
    bool uHideUnity(){
        // Need to get the Objective C BOOL value from above, my c# script will read get this value once retrieved
        return [MyUnityPlugin hideUnityWindow]; //Tested with a build but not returning the true status, also not sure if it's bc it's a BOOL vs a bool
    }
    
}
