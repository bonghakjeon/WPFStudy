﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LazyTreeView.Utils
{
    // 비트맵 이미지 파일 관리 해주는 유틸리티 구현 (2023.07.18 jbh)

    public static class ToggleImageUtils
    {
        public enum ExplorerType
        {
            Drive,      // 드라이브
            Directory,  // 디렉토리
            File        // 파일 
        }

        /// <summary>
        /// .png 파일 -> 비트맵 이미지 변환
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static BitmapImage GetBitmapImageByFileName(string fileName)
        {
            return new BitmapImage(new Uri($"./../Images/{fileName}", UriKind.Relative));
        }

        // TODO: 오류 코드 "CS8370" 오류 메시지 "'nullable 참조 형식' 기능은 C# 7.3에서 사용할 수 없습니다. 8.0 이상의 언어 버전을 사용하세요." .Net 8.0 이상 언어 버전 설치 (2023.07.17 jbh)
        // 참고 URL - https://drehzr.tistory.com/872
        // TODO : 경고 메시지 코드 "CS8632" 경고 메시지 "c# 경고 CS8632 nullable 참조 형식에 대한 주석은 코드에서 '#nullable' 주석 컨텍스트 내에만 사용되어야 합니다." 로직 보완 (2023.07.17 jbh)
        // 참고 URL - https://kukuta.tistory.com/359
        // C# Nullable 타입 참고 URL - https://www.csharpstudy.com/CSharp/CSharp-nullable.aspx
#nullable enable   // 참조 타입 변수라도 null을 대입하면 경고

        public static (BitmapImage? opendedImage, BitmapImage? closedImage) GetExplorers(ExplorerType explorerType)
        {
            BitmapImage? opendedImage = null;
            BitmapImage? closedImage = null;

            // switch - case 문 실행 -> 각 case 마다 비트맵 이미지 따로 따로 넘겨줌
            switch (explorerType)
            {
                // .png 파일 -> 비트맵 이미지 변환 (메서드 "GetBitmapImageByFileName")
                case ExplorerType.Drive:      // 드라이브 
                    opendedImage = GetBitmapImageByFileName("opened-drive.png");
                    closedImage  = GetBitmapImageByFileName("closed-drive.png");
                    break;
                case ExplorerType.Directory:  // 디렉토리
                    opendedImage = GetBitmapImageByFileName("opened-folder.png");
                    closedImage  = GetBitmapImageByFileName("closed-folder.png");
                    break;
                case ExplorerType.File:       // 파일
                    opendedImage = null;
                    closedImage  = GetBitmapImageByFileName("file.png");
                    break;
            }

            return (opendedImage, closedImage);
        }
    }

#nullable disable  // nullable 전처리 비활성화

}

