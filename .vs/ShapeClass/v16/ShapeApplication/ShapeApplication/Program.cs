using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeApplication.Shape;

namespace ShapeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Shapes oShapes = new Shapes();
            
            //Circle
            oShapes.Add(new Circle(6.0d));
            oShapes.Add(new Circle(3.5d));
            //Triangle
            oShapes.Add(new Triangle(10.0d, 10.0d, 10.0d));
            oShapes.Add(new Triangle(23.5d, 15.0d, 15.0d));
            oShapes.Add(new Triangle(40.5d, 55.5d, 20.0d));
            oShapes.Add(new Triangle(40.5d, 64.0d, 30.0d));
            //Square
            oShapes.Add(new Square(5.0d, 5.0d));
            oShapes.Add(new Square(5.0d, 11.5d));
            oShapes.Add(new Square(5.0d, 15.5d));

            try
            {
                
                Console.WriteLine("Want to Sort?  : Yes = y, No = n");
            
                string ch = Console.ReadLine();

                if(ch == "y")
                {
                    //Sort
                    Console.WriteLine("Sort Type?  : AreaDescending=1, AreaAscending=2, PerimeterDescending=3, PerimeterAscending=4");
                    int iInputNum = int.Parse(Console.ReadLine());

                    switch (iInputNum)
                    {
                        case 1:
                            oShapes.SortAreaDesc();
                            break;
                        case 2:
                            oShapes.SortAreaAsc();
                            break;
                        case 3:
                            oShapes.SortPerimeterDesc();
                            break;
                        case 4:
                            oShapes.SortPerimeterAsc();
                            break;
                        default:
                            break;
                    }
                }
                else if(ch == "n")
                { 
                    //no sort
                }
                else
                {
                    Console.WriteLine("Want to Sort?  : Yes = y, No = n");
                }

                //Process
                Console.WriteLine("Please Select Number : View ShapesInfo = 1, View ShapesCount = 2, SaveFile = 3 ");
                int iProcess = int.Parse(Console.ReadLine());

                switch (iProcess)
                {
                    case 1:
                        //View ShapesInfo
                        StringBuilder oStb = new StringBuilder();
                        foreach(AbstractShape os in oShapes.LstShapes)
                        {
                            oStb.Append("Name = " + os.ShapeName);
                            oStb.Append(", Area = " + os.SurfaceArea);
                            oStb.AppendLine(", Perimeter = " + os.Perimeter);
                        }

                        Console.WriteLine("*****ShapesInfo*****");
                        Console.WriteLine(oStb.ToString());

                        break;
                    case 2:
                        //View ShapesCount
                        Console.WriteLine("*****ShapesCount*****");
                        Console.WriteLine(oShapes.GetShapeCount());
                        break;
                    case 3:
                        //SaveFile
                        Console.WriteLine("Please Select SaveType : xml = 1, json = 2, binary = 3,etc = 4");
                        int iSaveType = int.Parse(Console.ReadLine());

                        //Save Paht = Desktop
                        string path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                        string filePath = string.Empty;
                        string savePath = string.Empty;
                        switch (iSaveType)
                        {   
                            case 1:
                                //xml
                                filePath = "ShapeFile.xml";
                                savePath = System.IO.Path.Combine(path, filePath);
                                oShapes.SaveToXMLFile(savePath);
                                break;
                            case 2:
                                //json
                                filePath = "ShapeFile.json";
                                savePath = System.IO.Path.Combine(path, filePath);
                                oShapes.SaveToJSONFile(savePath);
                                break;
                            case 3:
                                //binary
                                filePath = "ShapeFile.bin";
                                savePath = System.IO.Path.Combine(path, filePath);
                                oShapes.SaveToBinaryFile(savePath);
                                break;
                            case 4:
                                //etc(txt)
                                filePath = "ShapeFile.txt";
                                savePath = System.IO.Path.Combine(path, filePath);
                                oShapes.SaveToTXTFile(savePath);
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Input Error");
                        break;
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine("Input Error : " + ex.ToString());
            }
            finally
            {
                Console.WriteLine("\n");
                Console.WriteLine("Please Enter AnyKey");
                Console.ReadKey();
            }

        }
    }


}
