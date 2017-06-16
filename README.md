# CopyFilesFromDev

## Задание
Написать программу, которая при подключении нового диска осуществляет поиск всех файлов и копирование их себе.

## Реализация
* IDE: MSVS 2015
* LANG: C#, Windows Forms

## Описание приложения
После запуска программы ожидается подключение USB-диска. 
Когда диск определяется, на экран выводятся расширения и все найденные файлы. 
После ожидания 10 сек произойдет автоматическое копирование всех текстовых файлов. 
Чтобы это предотвратить, достаточно кликнуть по пустой области окна.
После чего пользователь может выбрать тип расширения, файлы которого хочет скопировать себе. 
При нажатии на кнопку "Копировать" производится копирование выбранных файлов в созданный каталог, 
имя которого соответствует метке подключенного диска.

## Скриншоты
![ScreenShot](https://raw.github.com/insendend/CopyFilesFromDev/master/CopyFilesFromDev/Screens/scrn1.jpg)
![ScreenShot](https://raw.github.com/insendend/CopyFilesFromDev/master/CopyFilesFromDev/Screens/scrn2.jpg)
![ScreenShot](https://raw.github.com/insendend/CopyFilesFromDev/master/CopyFilesFromDev/Screens/scrn3.jpg)
