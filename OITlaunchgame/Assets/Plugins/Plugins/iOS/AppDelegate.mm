//
//  AppDelegate+cordova2unity.m
//  HelloCordova
//
//  Created by Shaw Walters on 9/13/16.
//
//

#import "AppDelegate.h"
#import "MainViewController.h"
#import "UnityInterface.h"

extern "C" void OpenCVForUnitySetGraphicsDevice(void* device, int deviceType, int eventType);
extern "C" void OpenCVForUnityRenderEvent(int marker);


@implementation AppDelegate

- (void)shouldAttachRenderDelegate;
{
    UnityRegisterRenderingPlugin(&OpenCVForUnitySetGraphicsDevice, &OpenCVForUnityRenderEvent);
}

- (UIWindow *)unityWindow {
    return UnityGetMainWindow();
}


- (void) showUnityWindow{
    NSLog(@"showUnityWindow");
    [self.unityWindow makeKeyAndVisible];
    
}

-(void) hideUnityWindow {
    NSLog(@"hideUnityWindow");
    [self.window makeKeyAndVisible];
    
}

- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    self.viewController = [[MainViewController alloc] init];
    
    self.unityController = [[UnityAppController alloc] init];
    [self.unityController application:application didFinishLaunchingWithOptions:launchOptions];
    
    
    return [super application:application didFinishLaunchingWithOptions:launchOptions];
}

-(void)applicationWillResignActive:(UIApplication *)application{
    [self.unityController applicationWillResignActive:application];
    NSLog(@"applicationWillResignActive");
}


-(void)applicationDidEnterBackground:(UIApplication *)application{
    [self.unityController applicationDidEnterBackground:application];
    NSLog(@"applicationDidEnterBackground");
}

-(void)applicationWillEnterForeground:(UIApplication *)application{
    [self.unityController applicationWillEnterForeground:application];
    NSLog(@"applicationWillEnterForeground");
}

-(void)applicationDidBecomeActive:(UIApplication *)application{
    [self.unityController applicationDidBecomeActive:application];
        NSLog(@"applicationDidBecomeActive");
}

-(void)applicationWillTerminate:(UIApplication *)application{
    [self.unityController applicationWillTerminate:application];
    NSLog(@"applicationWillTerminate");
}


@end
