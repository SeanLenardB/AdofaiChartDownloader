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

## 特别说明 I want to highlight these

*如果下载出现大量的紫色字，说明你被Google Drive屏蔽了，稍作等待即可。

*If you encounter lots of purple(magenta) text while using the software to download charts, it usually indicates that your ip is temporarily forbidden by Google Drive and that can be solved by waiting for a couple of time.

↑ The issue above is caused by my programming. In the programme I used a google drive download link that does not require logging in to the drive. And of course, if Google server received frequent ANONYMOUS download requests from the same ip, it will forbid that ip temporarily. However, this will not affect the case where you download charts from google drive using a web browser, because in that case, you'll be downloading the charts in the name of your account, and that's not like the requests made by the programme. I personally didn't want to dive into Google's token algorithms, due to two reasons:

1, I'm personally too lazy to read their docs, and that's because I've tried, but no success.

2, The software was originally planned to share with my bros in China, where some of the people can't register Google Drive accounts. Therefore if I implement logging in feature, many of the people will become frustrated because they don't even have one to log in.

That being said, I would be happy if someone can fix this problem (right now without logging in Google accounts, the downloader can only be at about 5 second/chart, but once it's upgraded with that feature, multi-threading can help improve the download speed, at about 1 second/chart, or even faster). If that feature is implemented sometime in the future, I'll probably make two releases, with one without login, and the other with login.

*如果下载出现红色字“WTF is that link?”，说明该谱面应该被定级为-2（通常情况）。当然，也有可能是我编程没有想到所有google drive的链接形式。所以，确保你去Errors.txt瞅一眼那些链接，自己访问一下看看是不是直链。如果是，请提交issues。

*If you encounter lots of red text saying "WTF is that link?" while using the software to download charts, it generally implies that EITHER the link is not a direct link (for example the link is directing us to a google drive folder), OR the link is just broken (getting 404 requests). In both cases, the chart should be (in my understanding of censorship criteria) marked -2. BUT, there's also possibilities where I'm just forgetting a new type of google drive link, therefore make sure to check Errors.txt and see whether the link is really broken / not direct link, or is just a bug. If it's a bug, please submit an issue.

↑ This is because my approach to google drive links is by first getting the file id, then download with a specific link (which can be found in my programme). However, google drive links are so interesting that getting the file id is hard. There's at least 3 types of google drive links (as far as I know).

If there's any better ways to get the file id, please submit a pull request.
