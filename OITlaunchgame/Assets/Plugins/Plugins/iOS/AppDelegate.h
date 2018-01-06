//
//  AppDelegate+cordova2unity.h
//  HelloCordova
//
//  Created by Shaw Walters on 9/13/16.
//
//

#import <UIKit/UIKit.h>
#import <Cordova/CDVViewController.h>
#import <Cordova/CDVAppDelegate.h>
#import "AppDelegate.h"
#import "UnityAppController.h"


@interface AppDelegate : CDVAppDelegate

@property (nonatomic, strong) UIWindow* unityWindow;

@property (nonatomic, strong) UnityAppController *unityController;

- (UIWindow *)unityWindow;

- (void)shouldAttachRenderDelegate;

- (void)showUnityWindow;
- (void)hideUnityWindow;

@end

