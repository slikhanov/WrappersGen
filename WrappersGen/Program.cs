using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrappersGen
{
    class Program
    {
        static void Main(string[] args)
        {
            ClangSharp.Index idx = new ClangSharp.Index();
            var options = new[] 
            {
                @"-x",
                @"c++",
                @"-ID:\VQ\perforce\slikhano_wsi_vq_ws\Azure\include\WxKernel"
            };

            var translationUnit = idx.CreateTranslationUnit(
                    @"D:\VQ\perforce\slikhano_wsi_vq_ws\Azure\include\WxKernel\Builder\Scene\WxdDataView.h",
                    options);
            foreach (var diag in translationUnit.Diagnostics)
            {
                System.Console.WriteLine(diag.Description);
            }
            var c = translationUnit.Cursor;
            c.VisitChildren((cursor, parent) => 
            {
                if (cursor.DisplayName == @"WxdDataView")
                {
                    System.Console.WriteLine(cursor.Definition);
                }
                return ClangSharp.Cursor.ChildVisitResult.Continue;
            });
        }
    }
}
