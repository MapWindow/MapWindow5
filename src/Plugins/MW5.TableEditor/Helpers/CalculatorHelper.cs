using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Helpers
{
    public static class CalculatorHelper
    {
        public static string GetShapeFunction(this GeometryType type)
        {
            switch (type)
            {
                case GeometryType.Point:
                case GeometryType.MultiPoint:
                    return "ShapeX ShapeY ShapeZ";
                case GeometryType.Polyline:
                    return "ShapeXFirst ShapeYFirst ShapeZFirst ShapeXLast ShapeYLast ShapeZLast";
                case GeometryType.Polygon:
                    return "CenterX CenterY";
            }
            return string.Empty;
        }
        
        public static string GetFunction(this CalculatorFunction fn)
        {
            switch (fn)
            {
                case CalculatorFunction.Operators:
                    return "+ - * / % \\ ^ |x| ! > >= < <= = <>";
                case CalculatorFunction.Booleans:
                    return "and or not xor nand nor nxor";
                case CalculatorFunction.Maths:
                    return "abs(x) cbr(x) comb(n,k) dec(x) exp(x) fact(x) fix(x) gcd(a,b,...) int(x) lcm(a,b,...) ln(x) logN(x,n) mod(a,b) perm(n,k) rnd(x) root(x,n) round(x,d) sgn(x) sqr(x)";
                case CalculatorFunction.Angles:
                    return "atn(x) cos(x) sin(x) tan(x) acos(x) asin(x) cosh(x) sinh(x) tanh(x) acosh(x) asinh(x) atanh(x) csc(x) sec(x) cot(x) acsc(x) asec(x) acot(x) csch(x) sech(x) coth(x) acsch(x) asech(x) acoth(x) rad(x) deg(x) grad(x)";
                case CalculatorFunction.Statistics:
                    return "min(a,b,...) max(a,b,...) mcd(a,b,...) mcm(a,b,...) Sum(a,b,...) Mean(a,b,...) Meanq(a,b,...) Meang(a,b,...) Var(a,b,...) Varp(a,b,...) Stdev(a,b,...) Stdevp(a,b,...) Step(x,a)";
                case CalculatorFunction.Time:
                    return "Year(d) date# DateSerial(a,m,d) Day(d) Hour(d) Minute(d) Month(d) now# Second(d) time# TimeSerial(h,m,s)";
                case CalculatorFunction.Other:
                    return "Psi(x) AiryA(x) AiryB(x) BesselI(x,n) BesselJ(x,n) BesselK(x,n) BesselY(x,n) beta(a,b) betaI(x,a,b) CBinom(k,n,x) Ci(x) Clip(x,a,b) CNorm(x,m,d) CPoisson(x,k) DBinom(k,n,x) digamma(x) psi(x) DNorm(x,μ,σ) DPoisson(x,k) Ei(x) Ein(x,n) Elli1(x) Elli2(x) Erf(x) FresnelC(x) FresnelS(x) gamma(x) gammai(a,x) gammaln(x) HypGeom(x,a,b,c) I0(x) J0(x) K0(x) PolyCh(x,n) PolyHe(x,n) PolyLa(x,n) PolyLe(x,n) Si(x) WAM(t,fo,fm,m) WEXP(t,p,a) WEXPB(t,p,a) WFM(t,fo,fm,m) WLIN(t,p,d) WPARAB(t,p) WPULSE(t,p,d) WPULSEF(t,p,a) WRAISE(t,p) WRECT(t,p,d) WRING(t,p,a,fm) WRIPPLE(t,p,a) WSAW(t,p) WSQR(t,p) WSTEPS(t,p,n) WTRAPEZ(t,p,d) WTRI(t,p) Y0(x) zeta(x)";
                case CalculatorFunction.Constants:
                    return "PI# pi# pi2# pi3# pi4# e# eu# phi# g# G# R# eps# mu# c# q# me# mp# mn# K# h# A#";
            }
            return string.Empty;
        }

        public static bool CalculateForFeatureSet(this MathParser parser, IFeatureSet fs, int targetFieldIndex)
        {
            var all = fs.NumSelected == 0;
            var table = fs.Table;
            var destColumnIndex = targetFieldIndex;

            var dict = BuildFieldMap(parser, fs);

            foreach (var ft in fs.Features)
            {
                if (!all && !ft.Selected)
                {
                    continue;
                }

                for (int i = 1; i <= parser.VarTop; i++)
                {
                    if (dict.ContainsKey(i))
                    {
                        parser.set_VarValue(i, Convert.ToDouble(table.CellValue(dict[i], ft.Index)));
                    }
                    else
                    {
                        SetShapeVariable(parser, fs, i, ft.Index);
                    }
                }

                var val = parser.Eval();
                table.EditCellValue(destColumnIndex, ft.Index, val);
            }

            return true;
        }

        private static Dictionary<int, int> BuildFieldMap(MathParser mathParser, IFeatureSet featureSet)
        {
            var dict = new Dictionary<int, int>();  // var index, field index

            var shapeFunctions = GetShapeFunction(featureSet.GeometryType).ToLower().Split(' ').ToList();

            for (int i = 1; i <= mathParser.VarTop; i++)
            {
                string name = mathParser.get_VarName(i).ToLower();
                if (!shapeFunctions.Contains(name))
                {
                    int fieldIndex = featureSet.Fields.IndexByName(mathParser.get_VarName(i));
                    dict.Add(i, fieldIndex);
                }
            }
            
            return dict;
        }

        private static void SetShapeVariable(MathParser mathParser, IFeatureSet fs, int varIndex, int shapeIndex)
        {
            var geom = fs.Features[shapeIndex].Geometry;
            switch (mathParser.get_VarName(varIndex).ToLower())
            {
                case "centerx":
                    mathParser.set_VarValue(varIndex, geom.Centroid.X);
                    break;
                case "centery":
                    mathParser.set_VarValue(varIndex, geom.Centroid.Y);
                    break;
                case "shapex":
                case "shapexfirst":
                    mathParser.set_VarValue(varIndex, geom.Points[0].X);
                    break;
                case "shapey":
                case "shapeyfirst":
                    mathParser.set_VarValue(varIndex, geom.Points[0].Y);
                    break;
                case "shapez":
                case "shapezfirst":
                    mathParser.set_VarValue(varIndex, geom.Points[0].Z);
                    break;
                case "shapexlast":
                    mathParser.set_VarValue(varIndex, geom.Points.Last().X);
                    break;
                case "shapeylast":
                    mathParser.set_VarValue(varIndex, geom.Points.Last().Y);
                    break;
                case "shapezlast":
                    mathParser.set_VarValue(varIndex, geom.Points.Last().Z);
                    break;
            }
        }
    }
}
