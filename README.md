# Song mass rename

I hate when I have to use some other program in order to fix my songs ID tags, so I decided to make a small application. In order to successfully use it, you will have to have your files in the `<artist> - <title>` format. It is also hardcoded to find only `mp3` files in the current directory.

## Parameters

You can use several parameters when running the application:

* `+print` _to prevent the console from closing when done_
* `+language <locale>` _to change the language. The included languages are English, Bulgarian (`bg`) and Danish (`da`)._

## Usages

In order to finish the project, I have used the [taglib-sharp](https://github.com/mono/taglib-sharp) library.

## License 

You are free to use, fork, pull and whatever you would like to do with the code :-)