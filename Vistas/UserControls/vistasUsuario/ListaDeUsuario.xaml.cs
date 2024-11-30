using ClasesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.UserControls.vistasUsuario
{
    /// <summary>
    /// Lógica de interacción para ListaDeUsuario.xaml
    /// </summary>
    public partial class ListaDeUsuario : UserControl
    {
        private CollectionViewSource vistaColeccionFiltrada;
        public ListaDeUsuario()
        {
            InitializeComponent();

            vistaColeccionFiltrada = Resources["VISTA_USER"] as CollectionViewSource;
        }

        private void txtUsuarioBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                vistaColeccionFiltrada.Filter += eventVistaUsuario_Filter;
            }
        }

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e) 
        {
            Usuario usuario = e.Item as Usuario;
            if(usuario.Usu_Name.StartsWith(txtUsuarioBusqueda.Text,StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted &= false;
            }

        }

        public FlowDocument CrearDocumentoDePrueba()
        {
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph(new Run("Este es un documento de prueba."));
            doc.Blocks.Add(p);
            return doc;
        }


        public FlowDocument CrearFlowDocumentDesdeDataGrid(DataGrid dataGrid)
        {
            var flowDoc = new FlowDocument
            {
                PagePadding = new Thickness(50),
                ColumnWidth = double.PositiveInfinity // Evita que las columnas se dividan
            };

            // Crear tabla para el FlowDocument
            Table table = new Table();
            flowDoc.Blocks.Add(table);

            // Añadir columnas a la tabla
            foreach (var column in dataGrid.Columns)
            {
                table.Columns.Add(new TableColumn
                {
                    Width = new GridLength(1, GridUnitType.Star) // Configura ancho proporcional
                });
            }

            // Encabezado de la tabla
            TableRowGroup headerGroup = new TableRowGroup();
            TableRow headerRow = new TableRow();
            foreach (var column in dataGrid.Columns)
            {
                headerRow.Cells.Add(new TableCell(new Paragraph(new Run(column.Header.ToString())))
                {
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center,
                    BorderBrush = Brushes.Black, // Borde del encabezado
                    BorderThickness = new Thickness(1), // Grosor del borde
                    Background = Brushes.LightGray // Fondo para distinguir encabezados
                });
            }
            headerGroup.Rows.Add(headerRow);
            table.RowGroups.Add(headerGroup);

            // Añadir filas con datos
            TableRowGroup dataGroup = new TableRowGroup();
            foreach (var item in dataGrid.Items)
            {
                if (item != null && dataGrid.ItemContainerGenerator.ContainerFromItem(item) is DataGridRow row)
                {
                    TableRow dataRow = new TableRow();
                    foreach (var column in dataGrid.Columns)
                    {
                        if (column.GetCellContent(row) is TextBlock cellContent)
                        {
                            dataRow.Cells.Add(new TableCell(new Paragraph(new Run(cellContent.Text)))
                            {
                                TextAlignment = TextAlignment.Left, // Ajustar alineación del texto
                                BorderBrush = Brushes.Black, // Borde de las celdas
                                BorderThickness = new Thickness(1), // Grosor del borde
                                Padding = new Thickness(5) // Espaciado dentro de las celdas
                            });
                        }
                    }
                    dataGroup.Rows.Add(dataRow);
                }
            }
            table.RowGroups.Add(dataGroup);

            return flowDoc;
        }


        //private void MostrarVistaPrevia(DataGrid dataGrid)
        //{
        //    FlowDocument documento = CrearFlowDocumentDesdeDataGrid(dataGrid);

        //    // Crear ventana para vista previa
        //    Window ventanaPrevia = new Window
        //    {
        //        Title = "Vista Previa de Impresión",
        //        Width = 800,
        //        Height = 600,
        //        Content = new FlowDocumentReader // Cambiar a FlowDocumentReader
        //        {
        //            Document = documento // Asignar FlowDocument al FlowDocumentReader
        //        }
        //    };

        //    ventanaPrevia.ShowDialog();
        //}

        private void MostrarVistaPrevia(DataGrid dataGrid)
        {
            FlowDocument documento = CrearFlowDocumentDesdeDataGrid(dataGrid);

            // Crear el botón de imprimir
            Button botonImprimir = new Button
            {
                Content = "Imprimir",
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            botonImprimir.Click += (s, e) =>
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    documento.PageWidth = printDialog.PrintableAreaWidth;
                    documento.PageHeight = printDialog.PrintableAreaHeight;
                    printDialog.PrintDocument(((IDocumentPaginatorSource)documento).DocumentPaginator, "Impresión de Usuarios");
                }
            };

            FlowDocumentScrollViewer viewer = new FlowDocumentScrollViewer
            {
                Document = documento, // Asignar el FlowDocument
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            // Crear un Grid para organizar el diseño
            Grid layoutGrid = new Grid();
            layoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Fila para el botón
            layoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Fila para el DocumentViewer

            // Añadir el botón y el DocumentViewer al Grid
            layoutGrid.Children.Add(botonImprimir);
            Grid.SetRow(botonImprimir, 0);

            layoutGrid.Children.Add(viewer);
            Grid.SetRow(viewer, 1);

            // Crear ventana para la vista previa
            Window ventanaPrevia = new Window
            {
                Title = "Vista Previa de Impresión",
                Width = 800,
                Height = 600,
                Content = layoutGrid
            };

            ventanaPrevia.ShowDialog();
        }


        private void Imprimir(DataGrid dataGrid)
        {
            FlowDocument documento = CrearFlowDocumentDesdeDataGrid(dataGrid);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                documento.PageWidth = printDialog.PrintableAreaWidth;
                documento.PageHeight = printDialog.PrintableAreaHeight;

                printDialog.PrintDocument(((IDocumentPaginatorSource)documento).DocumentPaginator, "Impresión de Usuarios");
            }
        }

        private void VistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            MostrarVistaPrevia(dtgUsuarios); // dtgUsuarios es el DataGrid definido en tu XAML
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            Imprimir(dtgUsuarios);
        }
    }
}
