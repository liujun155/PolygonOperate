using GpcWrapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonOperate
{
    public class Program
    {
        //"1,1;2,2;3,3"
        public static void Main(string[] args)
        {
            //args = new string[3];
            //string ss = "0,0;0,1;1,1;1,0";
            //string ss1 = "0,0;0,1;1,1;1,0";
            //string ss2 = "0";
            //args[0] = ss;
            //args[1] = ss1;
            //args[2] = ss2;

            if (args?.Count() != 3) return;
            try
            {
                string[] ptStr1 = args[0].Split(';');
                string[] ptStr2 = args[1].Split(';');
                //0：相差  1：相交  2：异或  3：合并
                GpcOperation operation = (GpcOperation)(int.Parse(args[2]));
                //组织多边形A顶点数据
                GpcWrapper.Polygon polygonA = new GpcWrapper.Polygon();
                PointF[] aa = new PointF[ptStr1.Count()];
                for (int i = 0; i < ptStr1.Count(); i++)
                {
                    var subPtStr = ptStr1[i].Split(',');
                    aa[i] = new PointF(float.Parse(subPtStr[0]),
                        float.Parse(subPtStr[1]));
                }
                VertexList vtxA = new VertexList(aa);
                polygonA.AddContour(vtxA, false);

                //组织多边形B顶点数据
                GpcWrapper.Polygon polygonB = new GpcWrapper.Polygon();
                PointF[] bb = new PointF[ptStr2.Count()];
                for (int i = 0; i < ptStr2.Count(); i++)
                {
                    var subPtStr = ptStr2[i].Split(',');
                    bb[i] = new PointF(float.Parse(subPtStr[0]),
                        float.Parse(subPtStr[1]));
                }
                VertexList vtxB = new VertexList(bb);
                polygonB.AddContour(vtxB, false);
                //调用GPC库的剪辑算法
                GpcWrapper.Polygon result = polygonA.Clip(operation, polygonB);
                //组织返回结果字符串
                if (result.Contour == null || result.Contour.Count() == 0)
                {
                    Console.WriteLine("");
                    return;
                }
                string str = string.Join(";", result.Contour[0].Vertex);
                str = str.Replace("(", string.Empty).Replace(")", string.Empty);
                Console.WriteLine(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
