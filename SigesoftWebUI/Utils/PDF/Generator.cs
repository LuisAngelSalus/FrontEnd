using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SigesoftWebUI.Utils.PDF
{
    public static class Generator
    {
        public class Employee
        {
            public string Name { get; set; }
            public bool valUno { get; set; }
            public bool ValDos { get; set; }
            public bool ValTres { get; set; }
        }

        public static List<Employee> GetAllEmployess() =>
            new List<Employee>
            {
                new Employee { Name="Examen 1", valUno=true, ValDos=true, ValTres=true},
                new Employee { Name="Examen 2", valUno=false, ValDos=true, ValTres=true},
                new Employee { Name="Examen 3", valUno=false, ValDos=true, ValTres=false},
                new Employee { Name="Examen 4", valUno=false, ValDos=true, ValTres=false},
                new Employee { Name="Examen 5", valUno=true, ValDos=true, ValTres=false}
            };

        public static string GetHTMLString(/*input futuro*/)
        {
            var employess = GetAllEmployess();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html lang='en'>
                        <head>
                            <meta charset='UTF-8'>
                            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                            <meta http-equiv='X-UA-Compatible' content='ie=edge'>
                            <title>Document</title>
                            <style>
                                table {
                                    font-family: arial, sans-serif;
                                    border-collapse: collapse;
                                    width: 50%;
                                }
    
                                td,
                                th {
                                    border: 1px solid #dddddd;
                                    text-align: left;
                                    padding: 8px;
                                }
        
                                tr:nth-child(even) {
                                    background-color: #dddddd;
                                }
                            </style>
                        </head>
                        <body>
                            <div>
                                <table style='margin-right:5%; margin-left:5%;'>
                                    <tr>
                                        <td rowspan='3' style='padding: 0px; width: 300px; '><img src='assets/images/SLEmpresarial.png' style='width: 200px; ' alt=''></td>
                                        <td rowspan = '3' >
                                            <div style = 'text-align: center;width: 300px;' >
                                                <h3 style = 'margin: 0px;'> VISTA PREVIA </h3>
                                                <h3 style = 'margin: 0px;'> COTIZACIÓN </h3>
                                            </div>
                                        </td>
                                        <td style = 'padding: 0px;'> Propuesta </td>
                                        <td style = 'padding: 0px;width: 200px;'> 360.19 V1 </td>
                                    </tr>
                                    <tr>
                                        <td style = 'padding: 0px;' > Fecha </td>
                                        <td style = 'padding: 0px;width: 200px;' > 11 Nov 2019 </td>
                                    </tr>
                                    <tr>
                                        <td style = 'padding: 0px;' > Página </td>
                                        <td style = 'padding: 0px;width: 200px;' > 18 - 27 </td>
                                    </tr>
                                </table>
                            </div>
                            &ensp;
                            <div>
                                <table style='margin-right: 20%; margin-left: 20%;'>
                                    <tr>
                                        <th></th>
                                        <th>Perfil 1</th>
                                        <th>Perfil 2</th>
                                        <th>Perfil 3</th>
                                    </tr>");

            foreach (var item in employess)
            {
                sb.AppendFormat(@"
                                <tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                </tr>",
                                item.Name,
                                item.valUno ? "<input type='checkbox' checked>" : "<input type='checkbox'>",
                                item.ValDos ? "<input type='checkbox' checked>" : "<input type='checkbox'>",
                                item.ValTres ? "<input type='checkbox' checked>" : "<input type='checkbox'>");
            }

            sb.Append(@"
                                </table>
                            </div>
                        </body>    
                        </html>");

            return sb.ToString();
        }
    }
}