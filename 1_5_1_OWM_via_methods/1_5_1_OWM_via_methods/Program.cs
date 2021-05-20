using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _1_5_1_OWM_via_methods
{
    class Program
    {
        /// <summary>
        /// Ввод чисел и проверка соответствия условиям
        /// </summary>
        /// <param name="paramMax">Максимальное значение для вводимого числа</param>
        /// <param name="paramMin">Минимальное значение для вводимого числа</param>
        /// <returns>Проверенное введенное число</returns>
        static int NumInput(int paramMax, int paramMin)
        {
            int input;
            while (true)
            {
                if (int.TryParse(ReadLine(), out input) && input <= paramMax && input >= paramMin) break;
                else Write($"Число должно быть целым от {paramMin} до {paramMax}, попробуйте еще раз: ");
            }
            return input;

        }

        /// <summary>
        /// Создание и вывод исходных матриц
        /// </summary>
        /// <returns>Возвращает заполненную матрицу</returns>
        /// <param name="mWidth">Ширина переданной матрицы</param>
        /// <param name="mHeight">Высота переданной матрицы</param>
        static int[,] CreateMatrix (byte mWidth, byte mHeight)
        {
            Random randy = new Random();
            int[,] matrix = new int[mWidth, mHeight];

            for (byte ind_2 = 0; ind_2 < mHeight; ind_2++)
            {
                for (byte ind = 0; ind < mWidth; ind++)
                {
                    matrix[ind, ind_2] = randy.Next(1, 100);
                    Write($"{matrix[ind, ind_2],3} ");
                }
                WriteLine();
            }

            return matrix;
        }

        /// <summary>
        /// Умножение матрицы на число и вывод результата в консоль
        /// </summary>
        /// <param name="mWidth">Ширина исходной матрицы</param>
        /// <param name="mHeight">Высота исходной матрицы</param>
        /// <param name="factor">Множитель матрицы</param>
        /// <param name="matrix">Исходная матрица</param>
        static void MatrixNumbMultip (byte mWidth, byte mHeight, byte factor, int[,] matrix)
        {
            for (byte ind_2 = 0; ind_2 < mHeight; ind_2++)
            {
                for (byte ind = 0; ind < mWidth; ind++)
                {
                    Write($"{matrix[ind, ind_2] * factor,4} ");
                }
                WriteLine();
            }
        }

        /// <summary>
        /// Сложение/Вычитание матриц в зависимости от выбора и вывод результата в консоль
        /// </summary>
        /// <param name="mWidth">Ширина обеих матриц</param>
        /// <param name="mHeight">Высота обеих матриц</param>
        /// <param name="choise">Параметр для определения нужного действия / Изначальный выбор действия с матрицами</param>
        /// <param name="matrix">Первая исходная матрица</param>
        /// <param name="matrix2">Вторая исходная матрица</param>
        static void MatrixAddition(byte mWidth, byte mHeight, byte choise , int[,] matrix, int[,] matrix2)
        {
            for (byte ind_2 = 0; ind_2 < mHeight; ind_2++)
            {
                for (byte ind = 0; ind < mWidth; ind++)
                {
                    if (choise == 2) Write($"{matrix[ind, ind_2] + matrix2[ind, ind_2],3} ");
                    else if (choise == 3) Write($"{matrix[ind, ind_2] - matrix2[ind, ind_2],3} ");
                }
                WriteLine();
            }
        }

        /// <summary>
        /// Перемножение матриц и вывод результата в консоль
        /// </summary>
        /// <param name="mWidth">Ширина первой матрицы / Длинна перемножаемых строк и столбцов</param>
        /// <param name="mHeight">Высота первой матрицы / Высота результирующей матрицы</param>
        /// <param name="mWidth_2">Ширина второй матрицы / Ширина результирующей матрицы</param>
        /// <param name="matrix">Первая исходная матрица</param>
        /// <param name="matrix2">Вторая исходная матрица</param>
        static void MatrixMultip(byte mWidth, byte mHeight, byte mWidth_2, int[,] matrix, int[,] matrix2)
        {
            int buf;
            for (byte ind_2 = 0; ind_2 < mHeight; ind_2++)
            {
                for (byte ind = 0; ind < mWidth_2; ind++)
                {
                    buf = 0;
                    for (byte multip = 0; multip < mWidth; multip++)
                    {
                        buf += matrix[multip, ind_2] * matrix2[ind, multip];
                    }
                    Write($"{buf,6} ");
                }
                WriteLine();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                byte mWidth;
                byte mHeight;
                byte mWidth_2;
                byte mHeight_2;
                byte factor;
                byte choise;

                #region Выбор режима работы

                Write("Какое действие нужно провести с матрицами?" +
                    "\n(1 - Умножение на число; 2 - Сложение; 3 - Вычитание; 4 - Перемножение)" +
                    "\nВыбор: ");

                choise = (byte)NumInput(4, 1);

                WriteLine();

                #endregion

                if (choise == 1)
                {
                    WriteLine("___Умножение матрицы на число___\n");
                    #region Задание размеров матрицы и множителя

                    Write("Введите кол-во столбцов первой матрицы ");
                    mWidth = (byte)NumInput(32, 1);

                    Write("Введите кол-во строк первой матрицы ");
                    mHeight = (byte)NumInput(32, 1);

                    Write("Введите множитель ");
                    factor = (byte)NumInput(64, 1);

                    #endregion
                    WriteLine("\n--------------------------------\n");
                    #region Создание матрицы

                    WriteLine("Исходная матрица:\n");
                    int[,] matrix_1 = CreateMatrix(mWidth, mHeight);

                    #endregion
                    WriteLine("\n--------------------------------\n");
                    #region Умножение на число и вывод результата на экран

                    WriteLine("Результат:\n");
                    MatrixNumbMultip(mWidth, mHeight, factor, matrix_1);

                    #endregion
                    ReadKey();
                    WriteLine("\n________________________________\n");
                }
                else if (choise == 2 || choise == 3)
                {
                    if (choise == 2) WriteLine("___Сложение матриц___\n");
                    else if (choise == 3) WriteLine("___Вычитание матриц___\n");
                    #region Задание размеров матриц

                    WriteLine("@Складывать можно только матрицы одинакового размера@");

                    Write("Введите кол-во столбцов обеих матриц ");
                    mWidth = (byte)NumInput(32, 1);

                    Write("Введите кол-во строк обеих матриц ");
                    mHeight = (byte)NumInput(32, 1);
                    

                    #endregion
                    WriteLine("\n--------------------------------\n");
                    #region Создание матриц

                    WriteLine("Исходные матрицы:\n");
                    int[,] matrix_1 = CreateMatrix(mWidth, mHeight);
                    WriteLine();
                    int[,] matrix_2 = CreateMatrix(mWidth, mHeight);

                    #endregion
                    WriteLine("\n--------------------------------\n");
                    #region Сложение/Вычитание матриц и вывод результата на экран

                    WriteLine("Результат:\n");
                    MatrixAddition(mWidth, mHeight, choise, matrix_1, matrix_2);

                    #endregion
                    ReadKey();
                    WriteLine("\n________________________________\n");
                }
                else if (choise == 4)
                {
                    WriteLine("___Перемножение матриц___\n");
                    #region Задание размеров матриц

                    WriteLine("@Перемножать матрицы можно только если кол-во столбцов первой матрицы равно кол-ву строк второй@");

                    while (true)
                    {
                        Write("Введите кол-во столбцов первой матрицы ");
                        mWidth = (byte)NumInput(32, 1);
                        Write("Введите кол-во строк первой матрицы ");
                        mHeight = (byte)NumInput(32, 1);
                        Write("Введите кол-во столбцов второй матрицы ");
                        mWidth_2 = (byte)NumInput(32, 1);
                        Write("Введите кол-во строк второй матрицы ");
                        mHeight_2 = (byte)NumInput(32, 1);

                        if (mWidth == mHeight_2) break;
                        else
                        {
                            WriteLine("\nКол-во столбцов первой и кол-во строк второй матрицы не совпадают, повторите ввод");
                        }
                    }

                    #endregion
                    WriteLine("\n--------------------------------\n");
                    #region Создание матриц

                    WriteLine("Исходные матрицы:\n");
                    int[,] matrix_1 = CreateMatrix(mWidth, mHeight);
                    WriteLine();
                    int[,] matrix_2 = CreateMatrix(mWidth_2, mHeight_2);

                    #endregion
                    WriteLine("\n--------------------------------\n");
                    #region Сложение/Вычитание матриц и вывод результата на экран

                    WriteLine("Результат:\n");
                    MatrixMultip(mWidth, mHeight, mWidth_2, matrix_1, matrix_2);

                    #endregion
                    ReadKey();
                    WriteLine("\n________________________________\n");
                }

                #region Повтор или выход

                WriteLine("Запустить заново? 1 - Повтор | 0 - Выход");
                Write("Выбор: ");
                if (NumInput(1, 0) == 0) break; // Завершение программы
                WriteLine();

                #endregion

            }
        }
    }
}
