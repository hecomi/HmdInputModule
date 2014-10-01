HMD Input Module for Unity
==========================

はじめに
--------
頭の向きによるカーソルと HMD によって決定を行う Unity 4.6 UI 用のカスタム Input Module 及び Raycaster です。

環境
----
* Unity 4.6.0b17

使い方
------
* `GraphicRaycaster` の代わりに `CrosshairRaycaster` を Canvas にアタッチ
* `EventSystem` オブジェクトの既存の Input Module を disabled にし、`HmdInputModule` をアタッチ

既知の問題点
------------
* `StandaloneInputModule` と併用しようとしていますが、マウスの座標がうまく変換できていません。

LICENSE
-------
The MIT License (MIT)

Copyright (c) 2014 hecomi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
