# windbg-theme
User friendly WinDBG theme.

For additional customization and installation options see <https://web.archive.org/web/20170707034002/https://blogs.msdn.microsoft.com/tess/2008/04/18/pimp-up-your-debugger-creating-a-custom-workspace-for-windbg-debugging/> or just do things as below:

- Clone this repo using `git clone git@github.com:yanglr/advDotnetDebugging.git`
- Copy the path of the theme file `.wew` you want to use.
- launch cmd executing commands with the path you copied just now:

    ```bash
    windbg.exe -Q -WF <PathOf_white.wew>
    ```

    ![Alt text](windbg-w.png?raw=true "WinDBG theme")


    If you fancy dark colors try:

    ```bash
    windbg.exe -Q -WF <PathOf_dark.wew>
    ```

    ![Alt text](windbg.png?raw=true "WinDBG theme")

    **Note**: It is necessary to replace the <PathOf_XXX> value to the actual path in your PC.
