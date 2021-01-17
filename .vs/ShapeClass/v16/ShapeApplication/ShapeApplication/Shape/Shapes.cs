using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ShapeApplication.Shape
{
    public class Shapes
    {
        private List<AbstractShape> lstShaps = new List<AbstractShape>();

        /// <summary>
        /// LstShapes Property
        /// </summary>
        public List<AbstractShape> LstShapes
        {
            get { return this.lstShaps; }
            set { this.lstShaps = value; }
        }

        /// <summary>
        /// Instance
        /// </summary>
        public Shapes()
        {
            lstShaps = new List<AbstractShape>();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="addShape"></param>
        public void Add(AbstractShape addShape)
        {
            lstShaps.Add(addShape);
        }

        /// <summary>
        /// Sort Area Descending order
        /// </summary>
        public void SortAreaDesc()
        {
            IOrderedEnumerable<AbstractShape> sorted = lstShaps.OrderByDescending(x => x.SurfaceArea);

            this.SortSwap(sorted);
        }

        /// <summary>
        /// Sort Area Ascending order
        /// </summary>
        public void SortAreaAsc()
        {
            IOrderedEnumerable<AbstractShape> sorted = lstShaps.OrderBy(x => x.SurfaceArea);
            this.SortSwap(sorted);

        }

        /// <summary>
        /// Sort Perimeter Descending order
        /// </summary>
        public void SortPerimeterDesc()
        {
            IOrderedEnumerable<AbstractShape> sorted = lstShaps.OrderByDescending(x => x.Perimeter);
            this.SortSwap(sorted);
        }

        /// <summary>
        /// Sort Perimeter Ascending order
        /// </summary>
        public void SortPerimeterAsc()
        {
            IOrderedEnumerable<AbstractShape> sorted = lstShaps.OrderBy(x => x.Perimeter);
            this.SortSwap(sorted);
        }

        /// <summary>
        /// Count of Shapes
        /// </summary>
        /// <returns>Shpes Count</returns>
        public string GetShapeCount()
        {
            int iCircleCnt = 0;
            int iSquareCnt = 0;
            int iTriangleCnt = 0;

            foreach (AbstractShape sh in LstShapes)
            {
                if(sh.GetType() == typeof(Circle))
                {
                    iCircleCnt++;
                }
                else if(sh.GetType() == typeof(Square))
                {
                    iSquareCnt++;
                }
                else if(sh.GetType() == typeof(Triangle))
                {
                    iTriangleCnt++;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("CircleCount=" + iCircleCnt);
            sb.Append(" , SquareCount=" + iSquareCnt);
            sb.Append(" , TriangleCount=" + iTriangleCnt);

            return sb.ToString();

        }

        /// <summary>
        /// SaveToBinaryFile
        /// </summary>
         /// <param name="path">SaveFileName</param>
        public void SaveToBinaryFile(string path)
        {
            StringBuilder sb = new StringBuilder();
            foreach (AbstractShape sh in LstShapes)
            {
                sb.Append("Name=" + sh.ShapeName);
                sb.Append(" : SurfaceArea=" + sh.SurfaceArea);
                sb.AppendLine(" : Perimeter=" + sh.Perimeter);
            }
            
            byte[] data = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(sb.ToString());
            System.IO.File.WriteAllBytes(path, data);
        }

        /// <summary>
        /// SaveToXMLFile
        /// </summary>
        /// <param name="path">SaveFileName</param>
        public void SaveToXMLFile(string path)
        {
             var XDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),                
                new XElement("Shapes", LstShapes.Select(x => new XElement("Shape",
                                               new XElement("ShapeName", x.ShapeName),
                                               new XElement("SurfaceArea", x.SurfaceArea),
                                               new XElement("Perimeter", x.Perimeter))))
                );

            XDoc.Save(path);

        }

        /// <summary>
        /// SaveToJSONFile
        /// </summary>
        /// <param name="path">SaveFileName</param>
        public void SaveToJSONFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new System.Text.UTF8Encoding(false)))
            {
                StringBuilder sb = new StringBuilder();
                foreach (AbstractShape sh in LstShapes)
                {
                    sb.Append("{\"ShapeName\":\"" + sh.ShapeName + "\"");
                    sb.Append(",\"SurfaceArea\":\"" + sh.SurfaceArea + "\"");
                    sb.Append(",\"Perimeter\":\"" + sh.Perimeter + "\"},");
                }
                //RemoveEnd(,)
                sb.Remove(sb.Length-1, 1);

                sw.Write(sb.ToString());
            }
        }

        /// <summary>
        /// SaveToTXTFile
        /// </summary>
        /// <param name="path">SaveFileName</param>
        public void SaveToTXTFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new System.Text.UTF8Encoding(false)))
            {
                foreach(AbstractShape sh in LstShapes)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("Name=" + sh.ShapeName);
                    sb.Append(" : SurfaceArea=" + sh.SurfaceArea);
                    sb.AppendLine(" : Perimeter=" + sh.Perimeter);

                    sw.WriteLine(sb.ToString());

                }
            }
        }

        /// <summary>
        /// SortObject --> LstShapes
        /// </summary>
        /// <param name="sorted"></param>
        private void SortSwap(IOrderedEnumerable<AbstractShape> sorted)
        {
            List<AbstractShape> tmplstShaps = new List<AbstractShape>();
            tmplstShaps.AddRange(sorted);

            LstShapes.Clear();
            LstShapes.AddRange(tmplstShaps);
        }


    }



}
