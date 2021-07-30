# WorkingwithImages

An application which retrieves the images from the server and stores them in a local database (image caching) and in a realtime database (Firebase).

## Frameworks

Xamarin | Firebase | SQLite

## Architecture
In this application, we have followed the MVVM Pattern.

## Concepts

- MVVM
- Singleton
- IoC Container
- Online and Offline Database 
- FFImageLoading

## References

* https://www.pexels.com/api/
* https://xamarinmonkeys.blogspot.com/2019/01/xamarinforms-working-with-firebase.html
* https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases
* https://github.com/luberda-molinet/FFImageLoading

## Note

Replace your API keys for Pexel API (To retrieve the image) and for Firebase in the following file.

* [API Constant](https://github.com/dinesh4official/WorkingwithImages/blob/main/Regenesys/RegenesysCore/Constants/APIConstants.cs)

## Screenshot

### Online Images - Pexel API

<img src="https://github.com/dinesh4official/WorkingwithImages/blob/main/Screenshots/OnlineImages.jpeg" width="400" height="600">

### Offline Images - SQLite

<img src="https://github.com/dinesh4official/WorkingwithImages/blob/main/Screenshots/OfflineImages.jpeg" width="400" height="600">

### Firebase Images - Realtime Database (Firebase)

<img src="https://github.com/dinesh4official/WorkingwithImages/blob/main/Screenshots/FirebaseImages.jpeg" width="400" height="600">
