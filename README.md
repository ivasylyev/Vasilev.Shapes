# Vasilev.Shapes

SQL\CreateStructure.sql 
Создание структуры базы со статьями и тегами, а также наполенениями тестовыми данными

SQL\Select.sql - выбор всех пар «Тема статьи – тэг»

\Vasilev.Shapes.Library - Библиотека .NET Core с классами треугольника и круга, позволяющая вычислять их площади
\Vasilev.Shapes.Tests - Юнит-тесты, с использованием которых можно проверить работоспособность библиотеки

Поскольку по условию задания библиотеку предполагается предоставить внешним потребителям, при реализации основной упор сделан на проверку входных данных.
В этом случае мы исходим из принципа "никому не доверяй"
Также, в случае, если на вход поданы некорректные параметры, классы круга и треугольника немедленно выбрасывают исключения. Вызываеющий код должен обработать эти исключения.
Поэтому в конструкторах выполнен ряд проверок
В частности, входящие параметры (радиус круга и стороны треугольника не должны быть слишком маленькими или слишком большими, чтобы площадь не была бы равна нулю или не равна бесконечности.
Также, в связи с тем что double имеет 14-15 значащих цифр, нельзя допустить, чтобы стороны треугольника отличались друг от друга на 14 или более порядков

Возможно, код слишком "перегружен" излишними проверками. Однако, для библиотеки, которую могут использовать самыми разнообразными способами, мне кажется это приемлемым.
