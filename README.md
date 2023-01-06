# AdofaiChartDownloader
A downloader for ADOFAI.gg, with automatical renaming and data reading.

一个可以自动重命名ADOFAI.gg谱面的下载器

## 免责声明
使用本软件造成的各种纠纷，项目作者及贡献者概不负责。

The developers and contributers are not responsible for any conflicts caused by users of the project.

## 提示
本软件不会违反ADOFAI.gg和ADOFAI的使用条款。

This app will not violate ADOFAI.gg's or ADOFAI's terms of use.

## 使用教程（视频）
视频版：https://www.bilibili.com/video/BV1rY411m7Aa

## 使用教程（文字版）

运行闪退请安装.Net运行时7.0

If the app flashes and crashes, install .NET runtime 7.0.

(https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=7.0.0&arch=x64&rid=win10-x64)

1. 下载程序，并且打开管理员版ADOFAI.gg谱面excel（自己上discord找） Download the app and open the admin version of ADOFAI.gg forum sheet (find this in Discord yourself).

[V1.0 Hotfix后不用][Not necessary after V1.0 Hotfix]**请使用`Maps by Diff`表，不要用`Maps by ID`！！！ Use `Maps by Diff` sheet instead of `Maps by ID`!!!

2. 复制需要下载的谱面至本地，创建excel表格（`.xlsx`一定没问题, `.csv`，`.xls`应该也没问题），请复制全部列（`A`~`V`），否则无法下载。当然，如果你清楚的话，其实只有`A`、`B`、`C`、`D`、`E`、`S`列是必要的。 Copy and paste the charts you want to download to your computer, create an Excel file and save. (`.xlsx` will definitely work, `.csv`, `.xls` are supposed to work as well) Please copy all columns of the row (range `A` ~ `V`), otherwise the app may not work. In fact, the app will only read column `A`, `B`, `C`, `D`, `E`, `S`.

** 不要包含表头（`ID`, `Song`, `Artist`那一列） Do not include the first row of the whole sheet (the one that has `ID`, `Song`, `Artist`).

3. 先关闭表格，再打开程序，按照程序要求输入对应参数。一般来说，只需要输入第2步存放的表格位置即可。 First close the Excel, then open the app and do what it asks you to do. Generally you'll just need to input the file location of the Excel you created in 2.

4. 如果你无法下载，请科学。 

5. 如果程序在运行中出现紫色或红色的字，报错的下载链接会存储在同目录的文件下的`Errors.txt`。下载的谱面也会存储在同目录下。 If the app encounter issues, magenta/red texts will pop up. You may locate the related download link in `Errors.txt`. Both `Errors.txt` and charts will be saved in the same folder as the Excel file.

*如果出现其他错误，或有问题，请使用github的功能自行提交。

*If you encounter other issues, use github to submit them.
