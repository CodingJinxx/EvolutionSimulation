using System.Collections;
using System.Collections.Generic;
using LogicColor = Logic.Entities.Records.Color;
using RaylibColor = Raylib_cs.Color;

namespace DesktopUI.Tests.Data;

public class ColorToRaylibColorConversionData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] {new LogicColor(44, 21, 32), new RaylibColor(44, 21, 32, 255)};
        yield return new object[] {new LogicColor(123, 0, 62), new RaylibColor(123, 0, 62, 255)};
        yield return new object[] {new LogicColor(255, 253, 239), new RaylibColor(255, 253, 239, 255)};
        yield return new object[] {new LogicColor(105, 95, 4), new RaylibColor(105, 95, 4, 255)};
        yield return new object[] {new LogicColor(153, 213, 1), new RaylibColor(153, 213, 1, 255)};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}