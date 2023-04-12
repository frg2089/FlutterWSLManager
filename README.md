# Flutter WSL Manager

So that you don't have to create an extra copy of the Flutter SDK!

## How to use?

Make sure you have [.Net](https://dot.net/) 7.0 Runtime!

Make sure the value of `core.autocrlf` in the config of your Flutter SDK's git is `input`!

0. Download it from [Github Release](https://github.com/frg2089/FlutterWSLManager/releases/latest).

1. Create an environment variable named "FLUTTER_ROOT" at your Windows PC.  
   And set the value is Flutter SDK Path.
 
   ```bat
   SETX FLUTTER_ROOT "<Path To Your Flutter SDK>"
   ```
   Such as: `C:\Users\<username>\flutter`

2. Create an environment variable named "FLUTTER_ROOT" at your WSL.  
   And set the value is Flutter SDK Path.

   Such as: 
   ```shell
   # /etc/profile.d/flutter.sh
   export FLUTTER_ROOT="<Path To Your Flutter SDK>"
   ```
   Such as: `/mnt/c/Users/<username>/flutter`

3. Add the path of `Flutter WSL Manager` to the PATH.
   ```bat
   SETX PATH "%PATH%;<Path To Your Flutter WSL Manager>"
   ```

4. Done! Enjoy it!

## How to clone the Flutter SDK?

```powershell
git clone git@github.com:flutter/flutter.git --no-checkout -b stable
cd flutter
git config core.autocrlf input
git checkout stable
```

## I cloned the Flutter SDK. But I Forgot to set core.autocrlf is input. How can I do?

```powershell
git stash
git config core.autocrlf input
git reset --hard HEAD~1
git reset --hard origin/stable
git stash pop
```

