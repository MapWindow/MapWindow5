'Mathematics Expression Parser
'Taken from http://digilander.libero.it/foxes/mathparser/MathExpressionsParser.htm
' Licence statement from above:
' clsMathParser is freeware open software. We are happy if you use and promote it.
' You are granted a free license to use the enclosed software and any associated
' documentation for personal or commercial purposes, except to sell the original.
' If you wish to incorporate or modify parts of clsMathParser please give them a
' different name to avoid confusion. Despite the effort that went into building,
' there's no warranty, that it is free of bugs. You are allowed to use it at your
' own risk. Even though it is free, this software and its documentation remain
' proprietary products. It will be correct (and fine) if you put a reference about
' the authors in your documentation.
'
'Version 4.2.1 was adapted to VB2005 by E.A. Chiaradia (EAC)
'Based on the first version of Chris Michaelis included in the MapWindow Table Editor, 11/2006

Option Strict Off
Option Explicit On

Imports System.Math

Public Class clsMathParser


    '********************************************************************************
    '* CLASS: clsMathParser                                    v.4.2.1   1.03.07    *
    '*                                                        Leonardo Volpi        *
    '*                                                        Michael Ruder         *
    '*                                                        Thomas Zeutschler     *
    '*                                                        Lieven Dossche        *
    '*                                                        Arnaud d.Grammont     *
    '*  Math-Physical Expression Evaluation                                         *
    '*  for VB 6, VBA 97/2000/XP                                                    *
    '*  use the mMathSpecFun.bas module for special functions                       *
    '********************************************************************************
    '-------------------------------------------------------------------------------
    ' CONSTANTS
    '-------------------------------------------------------------------------------
    Const HiVT As Integer = 100 'max variables for string
    Const HiET As Integer = 200 'max functions/operations for string
    Const HiARG As Integer = 20  'max function arguments
    Const HiF2 As Integer = 20  'max nested multi-variable functions 12.06.04
    Const HFOffset As Integer = 200 'offset for multi-var functions assignement
    Const PI_ As Double = 3.14159265358979
    Const DP_SET As Boolean = True 'decimal point setting "."
    '-------------------------------------------------------------------------------------------------------------
    'FUNCTION ALIAS
    '-------------------------------------------------------------------------------------------------------------
    'tables of fixed parameters functions
    Const Fun1V As String = "Abs Atn Atan Cos Exp Fix Int Ln Log Rnd Sgn Sin Sqr Cbr Tan Acos Asin " & _
        "Cosh Sinh Tanh Acosh Asinh Atanh Fact Not Erf Gamma Gammaln Digamma Zeta Ei AiryA AiryB " & _
        "csc sec cot acsc asec acot csch sech coth acsch asech acoth dec rad deg grad neg Si Ci " & _
        "fresnels fresnelc J0 Y0 I0 K0 Psi Year Month Day Hour Minute Second"
    Const Fun2V As String = "Comb Mod And Or Xor Beta Root Round Nand Nor NXor Perm " & _
        "LogN DPoisson CPoisson Ein BesselI BesselJ BesselK BesselY GammaI PolyLe PolyHe PolyCh PolyLa " & _
        "elli1 elli2 wtri wsqrt wsaw wraise wparab step"
    Const Fun3V As String = "DNorm CNorm DBinom CBinom BetaI Clip wrect wtrapez wlin wpulse wsteps wexp wexpb wpulsef wripple " & _
         "DateSerial TimeSerial"
    Const Fun4V As String = "HypGeom wring wam wfm"
    'Table of variable parameters functions
    Const FunxV As String = "max min sum mean meanq meang var varp stdev stdevp mcm mcd lcm gcd "
    '-------------------------------------------------------------------------------
    ' FUNCTION ENUMERATIONS
    '-------------------------------------------------------------------------------
    Const symRight As Short = -2        'right function (internal)
    Const symARGUMENT As Short = -1      'An Argument    (internal)
    Const symPlus As Short = 0         '+
    Const symMinus As Short = 1         '-
    Const symMul As Short = 2         '*
    Const symDiv As Short = 3         '/
    Const symPercent As Short = 4        '% percentage
    Const symDivInt As Short = 5         '\ integer division, added MR 20-06-02
    Const symPov As Short = 6         '^
    Const symAbs As Short = 7         '"abs", "|.|"
    Const symAtn As Short = 8         '"atn"
    Const symCos As Short = 9         '"cos"
    Const symSin As Short = 11        '"sin"
    Const symExp As Short = 12        '"exp"
    Const symFix As Short = 13        '"fix"
    Const symInt As Short = 14        '"int"
    Const symLn As Short = 15        '"ln"
    Const symLog As Short = 16        '"log"
    Const symRnd As Short = 17        '"rnd"
    Const symSgn As Short = 18        '"sgn"
    Const symsqrt As Short = 19        '"sqrt"
    Const symTan As Short = 20        '"tan"
    Const symAcos As Short = 21        '"acos"
    Const symAsin As Short = 22        '"asin"
    Const symCosh As Short = 23        '"cosh"
    Const symSinh As Short = 24        '"sinh"
    Const symTanh As Short = 25        '"tanh"
    Const symAcosh As Short = 26        '"acosh"
    Const symAsinh As Short = 27        '"asinh"
    Const symAtanh As Short = 28        '"atanh"
    Const symmod As Short = 29        '"mod"
    Const symFact As Short = 30        '"fact", "!"
    Const symComb As Short = 31        '"combinations or binomial coeff."
    Const symGT As Short = 36        '">"
    Const symGE As Short = 37        '">as short ="
    Const symLT As Short = 38        '"<"
    Const symLE As Short = 39        '"<as short ="
    Const symEQ As Short = 40        '"as short ="
    Const symNE As Short = 41        '"<>"
    Const symAnd As Short = 42        '"and"
    Const symOr As Short = 43        '"or"
    Const symNot As Short = 44        '"not"
    Const symXor As Short = 45        '"xor"
    Const symErf As Short = 46        '"erf"
    Const symGamma As Short = 47        '"gamma"   Euler's gamma function
    Const symGammaln As Short = 48       '"gammaln" logarithm of gamma
    Const symDigamma As Short = 49       '"digamma"
    Const symBeta As Short = 50        '"beta"
    Const symZeta As Short = 51        '"zeta"
    Const symEi As Short = 52        '"ei"  Exponetial integral
    Const symCsc As Short = 53        '"csc  cosecant"
    Const symSec As Short = 54        '"sec  secant"
    Const symCot As Short = 55        '"cot  cotangent"
    Const symACsc As Short = 56        '"acsc  inverse cosecant"
    Const symASec As Short = 57        '"asec  inverse secant"
    Const symACot As Short = 58        '"acot  inverse cotangent"
    Const symCsch As Short = 59        '"csch  hyperbolic cosecant"
    Const symSech As Short = 60        '"sech  hyperbolic secant"
    Const symCoth As Short = 61        '"coth  hyperbolic cotangent"
    Const symACsch As Short = 62        '"acsch inverse hyperbolic cosecant"
    Const symASech As Short = 63        '"asech inverse hyperbolic secant"
    Const symACoth As Short = 64        '"acoth inverse hyperbolic cotangent"
    Const symCbr As Short = 65        '"cbr cube root"
    Const symRoot As Short = 66        '"root n-th root"
    Const symDec As Short = 67        '"dec  decimal part"
    Const symRad As Short = 68        '"rad  convert radiant to current angle unit"
    Const symDeg As Short = 69        '"deg  convert degree 360 to current angle unit"
    Const symRound As Short = 70        '"round"
    Const symGrad As Short = 71        '"grad  convert degree 400 to current angle unit"
    Const symNAnd As Short = 72        '"nand"
    Const symNOr As Short = 73        '"nor"
    Const symNXor As Short = 74        '"NXor"
    Const symNeg As Short = 75        '"neg sign change"
    Const symPerm As Short = 76        '"Perm Permutations"
    Const symLogN As Short = 77        '"LogN log N-base"
    Const symDPoiss As Short = 78        'Poisson density
    Const symCPoiss As Short = 79        'Poisson cumulative distribution
    Const symEin As Short = 80         '"Ein" Exponential integral n
    Const symSi As Short = 81         '"Integral Sine
    Const symCi As Short = 82         '"Integral cosine
    Const symFresS As Short = 83         '"Fresnel's Integral sine
    Const symFresC As Short = 84         '"Fresnel's Integral cosine
    Const symBessJ As Short = 85         '"Bessel's Jn(x)  1st kind
    Const symBessY As Short = 86         '"Bessel's Yn(x)  2nd kind
    Const symBessI As Short = 87         '"Bessel's In(x)  1st kind modified
    Const symBessK As Short = 88         '"Bessel's Kn(x)  2nd kind modified
    Const symJ0 As Short = 89        '"Bessel's J(x)  1st kind
    Const symY0 As Short = 90        '"Bessel's Y(x)  2st kind
    Const symK0 As Short = 91        '"Bessel's K(x)  1st kind modified
    Const symI0 As Short = 92        '"Bessel's I(x)  2st kind modified
    Const symGammaI As Short = 94        '"Gamma Incomplete
    Const symPolyLe As Short = 95        '"Legendre's polynomial
    Const symPolyLa As Short = 96        '"Laguerre's polynomial
    Const symPolyHe As Short = 97        '"Hermite's polynomial
    Const symPolyCh As Short = 98        '"Chebycev's polynomial
    Const symAiryA As Short = 99        '"Airy Ai(x) function
    Const symAiryB As Short = 100       '"Airy Bi(x) function
    Const symEllipt1 As Short = 101      '"Elliptic integral 1st kind
    Const symEllipt2 As Short = 102      '"Elliptic integral 2nd kind
    Const symWtri As Short = 103       'Triangular wave
    Const symWsqrt As Short = 104       'Square wave
    Const symWsaw As Short = 105       'saw wave
    Const symWraise As Short = 106       'raise wave
    Const symWparab As Short = 107       'parabolic wave
    Const symStep As Short = 108       'step
    ' > Berend 20041216
    Const symYear As Short = 150       ' Year(date) function
    Const symMonth As Short = 151       ' Month(date) function
    Const symDay As Short = 152       ' Day(date) function
    Const symHour As Short = 153       ' Hour(date) function
    Const symMinute As Short = 154       ' Minute(date) function
    Const symSecond As Short = 155       ' Second(date) function
    ' < Berend 20041216

    'constant > 200 for multi-arguments function.
    Const symDnorm As Short = HFOffset + 1      'Normal Density
    Const symCnorm As Short = HFOffset + 2      'Normal Cumulative Distribution
    Const symDBinom As Short = HFOffset + 3      'Binomial Density
    Const symCBinom As Short = HFOffset + 4      'Binomial Cumulative Distribution
    Const symHypGeo As Short = HFOffset + 5      'Hypergeometric function
    Const symBetaI As Short = HFOffset + 6      'Beta Incomplete
    Const symClip As Short = HFOffset + 7      'Clipping function
    Const symWrect As Short = HFOffset + 8      'rectang. wave
    Const symWtrapez As Short = HFOffset + 9     'trapez wavw
    Const symWlin As Short = HFOffset + 10     'linear wavw
    Const symWpulse As Short = HFOffset + 11     'pulse
    Const symWsteps As Short = HFOffset + 12     'steps wave
    Const symWexp As Short = HFOffset + 13     'expon. wavw
    Const symWexpb As Short = HFOffset + 14     'expon. bipolar wave
    Const symWpulsef As Short = HFOffset + 15    'pulse filtered
    Const symWripple As Short = HFOffset + 16    'ripple wave
    Const symWring As Short = HFOffset + 17     'ringing wavw
    Const symWam As Short = HFOffset + 18     'AM wave
    Const symWfm As Short = HFOffset + 19     'FM wave
    ' > Berend 20041213
    Const symDateSerial As Short = HFOffset + 20 ' DateSerial
    Const symTimeSerial As Short = HFOffset + 21 ' TimeSerial
    ' < Berend 20041213

    'constant > 300 for variables arguments function.
    Const symMin As Short = HFOffset + 101        '"min"
    Const symMax As Short = HFOffset + 102        '"max"
    Const symSum As Short = HFOffset + 103        '"Sum"
    Const symMean As Short = HFOffset + 104        '"arithmetic mean"
    Const symMeanq As Short = HFOffset + 105        '"quadratic mean"
    Const symMeang As Short = HFOffset + 106        '"geometric mean"
    Const symVar As Short = HFOffset + 107        '"variance"
    Const symVarp As Short = HFOffset + 108        '"variance pop."
    Const symStdev As Short = HFOffset + 109        '"std. deviation"
    Const symStdevp As Short = HFOffset + 110        '"std. deviation pop."
    Const symMcd As Short = HFOffset + 111        '"gcd"
    Const symMcm As Short = HFOffset + 112        '"lcm"

    '-------------------------------------------------------------------------------
    ' TYPE DECLARATIONS
    '-------------------------------------------------------------------------------
    Private Structure T_VTREC           'Variable record
        Dim Idx As Integer
        Dim Nome As String
        Dim Value As Double
        Dim Sign As Integer
        Dim Init As Boolean
    End Structure

    Private Class T_ETREC           'Expression Structure record
        Public Fun As String
        Public FunTok As Integer
        <VBFixedArray(HiARG)> Public Arg() As T_VTREC
        Public ArgTop As Integer
        Public ArgOf As Integer
        Public ArgIdx As Integer
        Public Value As Double
        Public Sign As Integer
        Public PosInExpr As Integer
        Public PriLvl As Integer
        Public PriIdx As Integer
        Public Cond As Integer

        Public Sub Initialize()
            ReDim Arg(HiARG)
        End Sub

        Public Sub New()
            Initialize()
        End Sub

    End Class

    Private Structure T_Funk            'Function record
        Dim FunName As String
        Dim ArgN As Integer
        Dim ArgCount As Integer
        Dim Sign As Integer
        Dim PosInExpr As Integer
    End Structure
    '-------------------------------------------------------------------------------
    ' LOCALS
    '-------------------------------------------------------------------------------
    Dim Expr As String   'Expression to parse/evaluate
    Dim ExprOK As Boolean  'Parsing result
    Dim VT() As T_VTREC  'Variables Table
    Dim ET() As T_ETREC  'Expression Structure Table
    Dim VTtop As Integer
    Dim ETtop As Integer
    Dim ErrMsg As String   'error message
    Dim ErrPos As Integer     'error position
    Dim ErrId As Integer     'error id
    Dim angle As String   'RAD GRAD DEG
    Dim DecRound As Integer
    Dim CvAngleCoeff As Double
    Dim VarsTbl As Collection   'additional object (bb 6-1-04)
    Dim Funk(5) As String    'Functions tables ******************** EAC verificare!!!
    Dim iInit As Integer      'Variables initialization counter
    Dim VarIniExp As Boolean   'Flag Variables initialization explicit
    Dim ErrorTbl() As String    'Error Message Table
    Dim DMS_conv As Boolean   'Flag dms conversion
    Dim Unit_conv As Boolean   'Flag unit conversion
    Dim ArgSep As String    'arguments separation symbol
    Dim DecSep As String    'decimal separation symbol

    '-------------------------------------------------------------------------------
    ' FUNCTIONS, METHODS and PROPERTIES
    '-------------------------------------------------------------------------------
    'class starting routine
    Public Sub New()
        'decimal point setting
        If DP_SET Then
            'independent from the international machine setting
            DecSep = "."
            ArgSep = ","
        Else
            'follow the the international machine setting
            DecSep = Decimal_Point_Is()
            If DecSep = "," Then ArgSep = ";" Else ArgSep = ","
        End If
        'initialize multi variable functions lists
        Funk(2) = Fun2V    'table of 2 parameters functions
        Funk(3) = Fun3V    'table of 3 parameters functions
        Funk(4) = Fun4V    'table of 4 parameters functions
        Funk(5) = FunxV    'table of variable parameters functions
        VarIniExp = False  'variables assignement explicit
        angle = "RAD"      'default angle radiant
        CvAngleCoeff = 1   'default angle convertion coefficient
        DMS_conv = True    'enable dms conversion
        Unit_conv = True   'enable unit conversion
        ErrorTab_Init()      'load error message table
    End Sub
    ' store expression as array of records. check syntax
    Public Function StoreExpression(ByVal strExpr As String) As Boolean
        Expr = Trim(strExpr)
        ExprOK = Parse(Expr)
        StoreExpression = ExprOK
    End Function
    '-------------------------------------------------------------------------------
    ' get the expression
    Public ReadOnly Property Expression() As String
        Get
            Expression = Expr
        End Get
    End Property
    '-------------------------------------------------------------------------------
    ' get the top of the var array (=N-1 bacause starts on 0)
    Public ReadOnly Property VarTop() As Integer
        Get
            VarTop = VTtop
        End Get
    End Property
    '-------------------------------------------------------------------------------
    ' get name of a variable. VL
    Public ReadOnly Property VarName(ByVal Index As Integer) As String
        Get
            If Index <= VTtop Then
                Return VT(Index).Nome
            End If

            Return ""
        End Get
    End Property
    '-------------------------------------------------------------------------------
    ' get value assigned to a variable
    '-------------------------------------------------------------------------------
    ' assign a value to a certain variable
    Public Property VarValue(ByVal Index As Integer) As Double
        Get
            If Index <= VTtop Then
                VarValue = VT(Index).Value
            End If
        End Get
        Set(ByVal Value As Double)
            If Index <= VTtop Then
                VT(Index).Value = Value
                VT(Index).Init = True
                iInit = iInit + 1
            End If
        End Set
    End Property

    '-------------------------------------------------------------------------------
    '(old version) get/set value assigned to a variable passed by its string name
    Public Property VarSymb(ByVal Name As String) As Double
        Get
            VarSymb = 0.0#
            On Error Resume Next
            VarSymb = VarsTbl(Name)
        End Get
        Set(ByVal value As Double)
            On Error Resume Next
            VT(VarsTbl(Name)).Value = value
            VT(VarsTbl(Name)).Init = True
            iInit = iInit + 1
        End Set
    End Property

    '-------------------------------------------------------------------------------
    ' get/assign value assigned to a variable passed by string or index (14.6.2004)
    Public Property Variable(ByVal Name) As Double
        Get
            Variable = 0
            If VarType(Name) = vbString Then
                On Error Resume Next
                Variable = VT(VarsTbl(Name)).Value
            Else
                On Error Resume Next
                Variable = VT(Name).Value
            End If
        End Get
        Set(ByVal value As Double)
            Dim Id As Integer
            On Error GoTo Error_Handler
            If VarType(Name) = vbString Then
                Id = VarsTbl(Name)
            Else
                Id = Name
            End If
            VT(Id).Value = value
            If VarIniExp Then  'Explicit initialization
                If VT(Id).Init = False Then
                    VT(Id).Init = True
                    iInit = iInit + 1
                End If
            End If
            Exit Property
Error_Handler:
            'nothing to do
        End Set
    End Property


    '-------------------------------------------------------------------------------
    ' get current setting for angle computing (RAD (default), DEG or GRAD)
    '-------------------------------------------------------------------------------
    ' set the unit of measure for angle computing (RAD (default), DEG or GRAD)
    Public Property AngleUnit() As String
        Get
            If angle = "" Then angle = "RAD"
            AngleUnit = angle
        End Get
        Set(ByVal Value As String)
            Select Case UCase(Value)
                Case "DEG"
                    angle = "DEG"
                    CvAngleCoeff = PI_ / 180
                Case "GRAD"
                    angle = "GRAD"
                    CvAngleCoeff = PI_ / 200
                Case Else
                    angle = "RAD"
                    CvAngleCoeff = 1
            End Select
        End Set
    End Property
    '-------------------------------------------------------------------------------
    ' get/set current setting for assignement constrain
    Public Property OpAssignExplicit() As Boolean
        Get
            OpAssignExplicit = VarIniExp
        End Get
        Set(ByVal value As Boolean)
            VarIniExp = value
        End Set

    End Property

    '-------------------------------------------------------------------------------
    ' get current setting for unit conversion
    ' enable/disable the unit conversion
    Public Property OpUnitConv() As Boolean
        Get
            OpUnitConv = Unit_conv
        End Get
        Set(ByVal value As Boolean)
            Unit_conv = value
        End Set
    End Property

    '-------------------------------------------------------------------------------
    ' get current setting for dms conversion
    ' enable/disable the dms conversion
    Public Property OpDMSConv() As Boolean
        Get
            OpDMSConv = DMS_conv
        End Get
        Set(ByVal value As Boolean)
            DMS_conv = value
        End Set
    End Property

    '-------------------------------------------------------------------------------
    ' get the error message
    Public ReadOnly Property ErrorDescription() As String
        Get
            ErrorDescription = ErrMsg
        End Get
    End Property
    '-------------------------------------------------------------------------------
    ' get the error message Id
    Public ReadOnly Property ErrorID() As Integer
        Get
            ErrorID = ErrId
        End Get
    End Property
    '-------------------------------------------------------------------------------
    ' get the error position
    Public ReadOnly Property ErrorPos() As Integer
        Get
            ErrorPos = ErrPos
        End Get
    End Property
    '-------------------------------------------------------------------------------
    ' evaluate expression
    Public Function Eval() As Double
        Dim ExprVal As Double

        If Not ExprOK Then GoTo Error_Handler
        ErrMsg = "" : ErrId = 0

        If VTtop > 0 Then
            'Check Explicit initialization
            If VarIniExp Then If VarEmpty() Then GoTo Error_Handler
            SubstVars() 'variables value substitution
        End If
        If Not Eval_(ExprVal) Then GoTo Error_Handler
        Eval = ExprVal
        Exit Function
        '
Error_Handler:
        On Error Resume Next
        Err.Raise(1001, "MathParser", ErrMsg)
    End Function
    '-------------------------------------------------------------------------------
    ' evaluate an expression with exactly 1 var
    Public Function Eval1(ByVal x As Double) As Double
        Dim i As Integer
        Dim j As Integer
        Dim ExprVal As Double
        '
        If Not ExprOK Then GoTo Error_Handler
        ErrMsg = "" : ErrId = 0

        If VTtop > 1 Then
            ErrMsg = getMsg(1)   '"too many variables"
            ErrPos = 1
            GoTo Error_Handler
        End If

        For i = 1 To ETtop
            For j = 1 To ET(i).ArgTop
                If ET(i).Arg(j).Idx <> 0 Then ET(i).Arg(j).Value = ET(i).Arg(j).Sign * x
            Next
        Next
        If Not Eval_(ExprVal) Then GoTo Error_Handler
        Eval1 = ExprVal
        Exit Function
        '
Error_Handler:
        On Error Resume Next
        Err.Raise(1002, "MathParser", ErrMsg)
    End Function
    '-------------------------------------------------------------------------------
    ' evaluate expression passing a vector
    Public Function EvalMulti(ByRef VarValue() As Double, Optional ByVal VarName As Object = Nothing)
        Dim ExprVal As Double, Vout() As Double
        Dim imax As Integer, imin As Integer, i As Integer, VarId As Integer

        If Not ExprOK Then GoTo Error_Handler
        ErrMsg = "" : ErrId = 0

        If VTtop > 0 Then
            'select the index variable index
            If IsNothing(VarName) Then VarName = 1
            On Error Resume Next
            If VarType(VarName) = vbString Then
                VarId = VarsTbl(VarName)
            Else
                VarId = VarName
            End If

            If Err.Number <> 0 Then
                ErrMsg = getMsg(2) 'variable not found"
                ErrPos = 1
                GoTo Error_Handler
            End If

            On Error GoTo 0
            imax = UBound(VarValue)
            imin = 1
            ReDim Vout(imax)
            For i = imin To imax
                VT(VarId).Value = VarValue(i)
                SubstVars()
                If Not Eval_(ExprVal) Then GoTo Error_Handler
                Vout(i) = ExprVal
            Next i
        Else

            ErrMsg = getMsg(2)  'Variable not found"
            ErrPos = 1
            GoTo Error_Handler
        End If

        EvalMulti = Vout

        Exit Function
        '
Error_Handler:
        On Error Resume Next
        Err.Raise(1001, "MathParser", ErrMsg)
    End Function
    '---------------------------------------------------------------------------------
    'class end routine
    'Private Sub Class_terminate()
    '    VarsTbl = Nothing           'xxz6
    'End Sub
    '-------------------------------------------------------------------------------
    ' Math Parse Routine
    ' rev 6-8-2004 Leonardo Volpi
    '-------------------------------------------------------------------------------
    Private Function Parse(ByVal strExpr As String) As Boolean
        Dim lExpr As String
        Dim chr As String '*1
        Dim char0 As String
        Dim SubExpr As String = ""
        Dim lenExpr As Integer
        Dim FunN() As T_Funk  'stack for N var. functions  12.06.04
        Dim GetNextArg As Boolean
        Dim SaveArg As String
        Dim Npart As Integer
        Dim Nabs As Integer
        Dim arrPriLvl() As Integer
        Dim Flag_exchanged As Boolean
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim LogicSymb As String
        Dim LastArg As Boolean
        Dim if2 As Integer        'stack counter for 2 var function 16.10.03
        Dim Sign As Integer        '7-1-04 saves the variable/function sign. Es "-x or -log(x)"
        Dim Node_Cond() As Integer        'store the condition-nodes
        Dim Node_Switch() As Integer        'store the switch-node
        Dim Node_max As Integer

        ReDim ET(HiET)
        ReDim VT(HiVT)
        ReDim FunN(HiF2)

        For z As Integer = 0 To HiET
            ET(z) = New T_ETREC
        Next
        For z As Integer = 0 To HiVT
            VT(z) = New T_VTREC
        Next
        For z As Integer = 0 To HiF2
            FunN(z) = New T_Funk
        Next

        VarsTbl = New Collection
        ETtop = 0
        VTtop = 0
        Parse = False
        iInit = 0     'reset variables assignement counter
        ErrMsg = ""   'VL
        ErrId = 0
        ErrPos = 0
        lExpr = Trim(strExpr)
        '***** abs |.| function counter
        i = NabsCount(lExpr)
        Nabs = i / 2
        If (2 * Nabs <> i) Then
            ErrMsg = getMsg(4) '"abs symbols |.| mismatch"  'VL
            ErrPos = 1
            Exit Function
        End If
        '***** begin parse process
        lenExpr = Len(lExpr)
        For i = 1 To lenExpr
            ErrPos = i
            LastArg = False
            j = 1
            chr = Mid(lExpr, i, 1)
            Select Case chr
                Case " "                                    '***** skip spaces
                Case "(", "[", "{"                          '***** open parentheses
                    Npart = Npart + 1                         'inc # open parentheses
                    If SubExpr <> "" Then                     'eval preceding text
                        Catch_Sign(SubExpr, Sign)                'catch the function sign (if any)
                        If SubExpr = "" And Sign = -1 Then
                            SubExpr = "Neg" : Sign = 1             'insert change-sign function
                        End If
                        If InList(SubExpr, Fun1V) Then          'monovariable function
                            ETtop = ETtop + 1                     '   store in ET
                            With ET(ETtop)
                                .PosInExpr = i                      'position in expr
                                .Fun = SubExpr                      'function name
                                .FunTok = GetFunTok(SubExpr)        'function Token (enum)
                                .PriLvl = Npart * 10                'priority level=open parenth*10
                                .ArgTop = 1                         'ntal Args=1
                                .Sign = Sign
                            End With
                        Else
                            'search for a function in the functions-tables
                            For k = 2 To 5
                                If InList(SubExpr, Funk(k)) Then Exit For
                            Next k
                            If k > 5 Then
                                'no function found
                                If IsNumeric_(SubExpr) Then
                                    ErrMsg = getMsg(5, i) '"Syntax error at pos: " & i
                                Else
                                    ErrMsg = getMsg(6, SubExpr, (i - Len(SubExpr))) '"Function < " & SubExpr & " > unknown at pos: " & (i - Len(SubExpr))
                                    ErrPos = i - Len(SubExpr)
                                End If
                                Exit Function
                            Else
                                if2 = if2 + 1
                                FunN(if2).FunName = SubExpr
                                FunN(if2).PosInExpr = i
                                ' > Mirko 20061018
                                If k = 5 Then
                                    'variable parameters function
                                    FunN(if2).ArgN = GetNumberOfArguments(Mid(lExpr, i))
                                    If FunN(if2).ArgN > HiARG Then
                                        ErrMsg = getMsg(9, i)  ' "Too many arguments at pos: " & i
                                        Exit Function
                                    End If
                                Else
                                    'fixed parameters function
                                    FunN(if2).ArgN = k
                                End If
                                ' < Mirko 20061018
                                FunN(if2).ArgCount = FunN(if2).ArgN - 1
                                FunN(if2).Sign = Sign
                            End If
                        End If
                        SubExpr = ""                            'start parsing for new subexpr
                    End If
                Case ")", "]", "}"                          '***** open parentheses
                    Npart = Npart - 1                         'dec # open parentheses
                    Flag_exchanged = True                     'closing brackets flag
                    If Npart < 0 Then                         'want to close to many brackets
                        ErrMsg = getMsg(9, i) '"Too many closing brackets at pos: " & i
                        Exit Function
                    End If
                Case "+", "-"                               '*****
                    If CheckExpo(SubExpr) Then              'fix bug 18-1-03  thanks to Michael Ruder
                        SubExpr = SubExpr & chr                  'continue parsing number
                    Else
                        If SubExpr = "" Then
                            char0 = getPrevChar(i, strExpr)
                            Select Case char0
                                Case "", "(", "[", "{", "|", ArgSep
                                    SubExpr = "0"
                                Case Else
                                    ErrMsg = getMsg(8) '"missing argument"  'preceding symbol is ")"
                                    Exit Function
                            End Select
                        End If
                        ETtop = ETtop + 1                       'store in ET
                        With ET(ETtop)
                            .PosInExpr = i
                            .Fun = chr
                            .FunTok = GetFunTok(chr)
                            .PriLvl = 2 + Npart * 10
                            .ArgTop = 2                           'two arguments
                        End With
                        GetNextArg = True                       'get second argument
                        If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                    End If
                Case "*", "/", "\"                      '*****
                    ETtop = ETtop + 1
                    With ET(ETtop)
                        .PosInExpr = i
                        .Fun = chr
                        .FunTok = GetFunTok(chr)
                        .PriLvl = 3 + Npart * 10
                        .ArgTop = 2                             'two arguments
                    End With
                    GetNextArg = True
                    If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                Case "^"
                    ETtop = ETtop + 1
                    With ET(ETtop)
                        .PosInExpr = i
                        .Fun = "^"
                        .FunTok = GetFunTok(chr)
                        .PriLvl = 4 + Npart * 10
                        .ArgTop = 2                             'two arguments
                    End With
                    GetNextArg = True
                    If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                Case "!"
                    ETtop = ETtop + 1
                    With ET(ETtop)
                        .PosInExpr = i
                        .Fun = "!"
                        .FunTok = GetFunTok(chr)
                        .PriLvl = 9 + Npart * 10
                        .ArgTop = 1                             'one argument
                    End With
                    SaveArg = SubExpr
                    If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                    SubExpr = SaveArg
                    Flag_exchanged = True
                Case "%"  'percentage
                    ETtop = ETtop + 1
                    With ET(ETtop)
                        .PosInExpr = i
                        .Fun = chr
                        .FunTok = GetFunTok(chr)
                        .PriLvl = 9 + Npart * 10
                        .ArgTop = 1                             'one argument
                    End With
                    GetNextArg = True
                    SaveArg = SubExpr
                    If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                    SubExpr = SaveArg
                Case ArgSep                                 'function argument separator
                    If FunN(if2).FunName = "" Then    '
                        ErrMsg = getMsg(9, i)  ' "Too many arguments at pos: " & i
                        Exit Function
                    End If
                    ETtop = ETtop + 1
                    With ET(ETtop)
                        .PosInExpr = FunN(if2).PosInExpr
                        .Fun = FunN(if2).FunName                 'previous stored
                        .FunTok = GetFunTok(FunN(if2).FunName)
                        .PriLvl = Npart * 10
                        .ArgTop = FunN(if2).ArgN                  'N arguments
                        .Sign = FunN(if2).Sign
                    End With
                    If FunN(if2).Sign < 0 Then FunN(if2).Sign = 1 'reset sign
                    GetNextArg = True
                    If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                    FunN(if2).ArgCount = FunN(if2).ArgCount - 1
                    If FunN(if2).ArgCount = 0 Then
                        FunN(if2).FunName = ""                     'reset function
                        FunN(if2).ArgN = 0
                        if2 = if2 - 1
                    End If
                Case "|"                                    '***** absolute symbol |.|
                    If SubExpr = "" Or SubExpr = "-" Then
                        Npart = Npart + 1                       'increment brackets PriLvl
                        ETtop = ETtop + 1
                        With ET(ETtop)
                            .PosInExpr = i
                            .Fun = "abs"                          'symbols |.| is similar to  abs(.)
                            .FunTok = GetFunTok("abs")
                            .PriLvl = Npart * 10
                            .ArgTop = 1                           'one argument
                            If SubExpr = "-" Then                 'fix sign bug 1.3.04. Thanks to Rodrigo Farinha
                                .Sign = -1
                                SubExpr = ""
                            End If
                        End With
                    Else
                        Npart = Npart - 1
                        Flag_exchanged = True                   '9.8.04 VL
                        If Npart < 0 Then                       'too many closing brackets
                            ErrMsg = getMsg(5, i) '"Syntax error at pos: " & i
                            Exit Function
                        End If
                    End If
                Case "=", "<", ">"                          'Logical operators
                    If LogicSymb = "" Then
                        If ETtop > 0 Then
                            'detect the Interval:=(a < x < b)
                            If InStr(1, " > < = <= >= <> =< =>", ET(ETtop).Fun) > 0 Then
                                'transform the Interval into (a<x)*(x<b) form
                                ETtop = ETtop + 1
                                With ET(ETtop)
                                    .PosInExpr = i
                                    .Fun = "*"                 'insert the hidden multiplication
                                    .FunTok = GetFunTok("*")
                                    .PriLvl = 3 + (Npart - 1) * 10
                                    .ArgTop = 2
                                End With
                                SaveArg = SubExpr
                                If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                                SubExpr = SaveArg           'pass the argument also to the logic symbol
                            End If
                        End If
                        ETtop = ETtop + 1
                        GetNextArg = True
                        If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                    End If

                    LogicSymb = LogicSymb & chr
                    With ET(ETtop)
                        .PosInExpr = i
                        .Fun = LogicSymb                        'logic symbol
                        .FunTok = GetFunTok(LogicSymb)
                        .PriLvl = 1 + Npart * 10
                        .ArgTop = 2                             'two argument
                    End With

                    If ET(ETtop).FunTok < 0 Then
                        ErrMsg = getMsg(5, i) '"Syntax error at pos: " & i    'Fix bug "==" thanks to Ricardo Martínez C.
                        Exit Function
                    End If

                Case "x", "y", "z", "X", "Y", "Z"           ''monomial coeff.
                    If IsNumeric_(SubExpr) Then               'fix 2.3.2003 thanks to Michael Ruder
                        ETtop = ETtop + 1                     'Ex: 7x  is converted into product 7*x
                        With ET(ETtop)
                            .PosInExpr = i
                            .Fun = "*"
                            .FunTok = GetFunTok("*")
                            .PriLvl = 3 + Npart * 10
                            .ArgTop = 2                             'two argument
                        End With
                        GetNextArg = True
                        If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
                        i = i - 1  'one step back
                    Else
                        SubExpr = SubExpr & chr
                    End If
                Case Else                                   '***** continue parsing
                    SubExpr = SubExpr & chr
            End Select

            If ETtop > UBound(ET) - 2 Then
                ErrMsg = getMsg(20) '"Too many operations"
                ErrPos = 1
                Exit Function
            End If

            If Flag_exchanged = True Then                 'after closing parenthesis
                If IsLetter(chr) Or IsDigit(chr) Or chr = DecSep Then   'these symbols are not allowed.
                    ErrMsg = getMsg(5, i) '"Syntax error at pos: " & i        'Fix bug thanks to PJ Weng.
                    Exit Function
                End If
            End If

            If GetNextArg Then
                GetNextArg = False
                Flag_exchanged = False
            Else
                LogicSymb = ""
            End If
        Next
        '---end of the main loop -----------------------

        If Npart > 0 Then                               'parentheses
            ErrMsg = getMsg(11) '"Not enough closing brackets"
            ErrPos = 1
            Exit Function
        End If
        If ETtop < 1 Then                               'no operation detected
            ETtop = 1
            With ET(ETtop)
                .PosInExpr = 1
                .Fun = "+"
                .FunTok = GetFunTok("+")
                .PriLvl = 1
                .ArgTop = 2
            End With
        End If
        For i = 1 To ETtop                              'init 2e argument
            j = ET(i).ArgTop
            If j > 2 Then j = 2
            ET(i).Arg(j) = ET(i + 1).Arg(1)
        Next

        If SubExpr <> "" Then                           'catch last argument or Vars
            j = ET(ETtop).ArgTop
            If j > 2 Then j = 2
            LastArg = True
            If Not Catch_Argument(SubExpr, j, LastArg) Then Exit Function
        Else
            'bug 7.10.03 last argument missing 3+ or sin() ...  thanks to Rodigro Farinha
            ErrMsg = getMsg(8) '"missing argument"
            Exit Function
        End If

        If if2 > 0 Then     '16.10.03
            ErrMsg = getMsg(8) '"missing argument"
            Exit Function
        End If

        ReDim Preserve ET(ETtop)
        ReDim Preserve VT(VTtop)

        Call Sort_table(arrPriLvl)                'start sort algorithm

        Call Build_Relations()           'build relations

        '-------------------------------------------------------------------------------
        'Search for the condition nodes in the graph appling the logic condition rules
        Control_Nodes(Node_Cond, Node_Switch, Node_max)
        If Node_max > 0 Then Call Sort_table(arrPriLvl) 'start sort algorithm
        '------------------------------------------------------------------------------

        Call Multi_Variables_Function()  'management of multi-variable functions

        Call Arguments_Cleanup()         'eliminate dependent arguments

        Parse = True

    End Function
    '---------------------------------------------------------------------------------
    Private Function Catch_Argument(ByRef SubExpr As String, ByVal j As Integer, ByVal LastArg As Boolean) As Boolean
        Dim Sign As Integer, retval As Double
        Catch_Argument = False
        If SubExpr = "" Then                        'no next argument found
            ErrMsg = getMsg(8) '"missing argument"
            Exit Function
        End If
        Catch_Sign(SubExpr, Sign)                    'breack the string into name and its sign +/-(if any)
        If SubExpr = "" Then                        'mod 5.4.2004 VL
            ErrMsg = getMsg(8) '"missing argument"   'fix bug for ++ or -- string. Thanks to PJ Weng
            Exit Function
        ElseIf convSymbConst(SubExpr, retval) Then      'check if argument is a symbolic constant #
            If ErrMsg <> "" Then Exit Function
            ET(ETtop).Arg(j).Value = Sign * retval
        ElseIf convEGU(SubExpr, retval) Then        'check if argument is Eng Units
            ET(ETtop).Arg(j).Value = Sign * retval
        ElseIf IsNumeric_(SubExpr) Then             'check if argument is number
            If DP_SET Then
                ET(ETtop).Arg(j).Value = Sign * Val(SubExpr)
            Else
                ET(ETtop).Arg(j).Value = Sign * CDbl(SubExpr)
            End If
        ElseIf cvDegree(SubExpr, retval, ErrMsg) Then      'check if argument is ddmmss format degree
            If ErrMsg <> "" Then Exit Function
            ET(ETtop).Arg(j).Value = Sign * retval    'angle sign bug 31.5.2004. thanks to PJ Weng
        Else

            If Not IsVariable(SubExpr) Then
                ErrMsg = getMsg(12, SubExpr) ' "Syntax error: " & SubExpr
                Exit Function
            End If

            StoreVar(SubExpr, LastArg, Sign)
            If VTtop > HiVT Then
                ErrMsg = getMsg(1)  '"too many variables"
                Exit Function
            End If
        End If
        ErrMsg = ""  'clear error message. fix bug 23.7.04. thanks to Ricardo Martínez C.
        ErrId = 0
        SubExpr = ""  'reset the substring
        Catch_Argument = True
    End Function
    '---------------------------------------------------------------------------------
    Private Sub Sort_table(ByRef arrPriLvl() As Integer)
        'sort table with exchanges algorithm
        Dim i As Integer, j As Integer, srtLo As Integer, srtHi As Integer, Tmp As Integer, Flag_exchanged As Boolean
        ReDim arrPriLvl(ETtop)                        'create array with priority levels
        For i = 1 To ETtop                              'and copy then from main array
            arrPriLvl(i) = ET(i).PriLvl
        Next
        For i = 1 To ETtop                              'fill sort order default 0 to ETtop
            ET(i).PriIdx = i
        Next
        srtLo = 1                                       '***** start sort algorithm
        srtHi = ETtop - 1
        Do
            Flag_exchanged = False
            For i = srtLo To srtHi Step 2
                j = i + 1
                If arrPriLvl(i) < arrPriLvl(j) Then
                    Tmp = arrPriLvl(j)
                    arrPriLvl(j) = arrPriLvl(i)
                    arrPriLvl(i) = Tmp
                    Tmp = ET(j).PriIdx
                    ET(j).PriIdx = ET(i).PriIdx
                    ET(i).PriIdx = Tmp
                    Flag_exchanged = True
                End If
            Next
            If srtLo = 1 Then
                srtLo = 2
            Else
                srtLo = 1
            End If
        Loop Until (srtLo = 1) And Not Flag_exchanged
    End Sub
    '---------------------------------------------------------------------------------
    Private Sub Build_Relations()
        Dim i As Integer, j As Integer, srtLo As Integer, srtHi As Integer
        For i = 1 To ETtop                              'build relations
            j = ET(i).PriIdx
            srtLo = j - 1
            Do While srtLo >= 0
                If ET(srtLo).ArgOf = 0 Then
                    Exit Do
                End If
                srtLo = srtLo - 1
            Loop
            srtHi = j + 1
            Do While srtHi <= ETtop
                If ET(srtHi).ArgOf = 0 Then
                    Exit Do
                End If
                srtHi = srtHi + 1
            Loop
            If (srtLo < 1) And (srtHi <= ETtop) Then            '
                ET(j).ArgOf = srtHi
                ET(j).ArgIdx = 1
            ElseIf (srtLo > 0) And (srtHi > ETtop) Then        '
                ET(j).ArgOf = srtLo
                ET(j).ArgIdx = ET(srtLo).ArgTop
                If ET(j).ArgIdx > 2 Then ET(j).ArgIdx = 2 'clipp
            ElseIf (srtLo > 0) And (srtHi <= ETtop) Then       '
                If (ET(srtLo).PriLvl) >= (ET(srtHi).PriLvl) Then  'take that one with the upper PriLvl
                    ET(j).ArgOf = srtLo
                    ET(j).ArgIdx = ET(srtLo).ArgTop
                    If ET(j).ArgIdx > 2 Then ET(j).ArgIdx = 2
                Else                                        '
                    ET(j).ArgOf = srtHi
                    ET(j).ArgIdx = 1
                End If
            Else
                Exit For
            End If
        Next

    End Sub
    '---------------------------------------------------------------------------------
    Private Sub Multi_Variables_Function()
        Dim i As Integer, j As Integer, p As Integer, k As Integer
        For i = 1 To ETtop
            If ET(i).ArgTop > 2 Then
                'change the intermediate multi-function token
                p = 3
                Do
                    j = ET(i).ArgOf
                    ET(i).ArgOf = ET(j).ArgOf
                    ET(i).ArgIdx = ET(j).ArgIdx 'Dipti DDWE-2709
                    With ET(j)
                        .ArgOf = i
                        .ArgIdx = p
                        .Fun = "@Right"
                        .FunTok = GetFunTok("@Right")
                        .ArgTop = 2
                    End With
                    p = p + 1
                Loop Until p > ET(i).ArgTop
                'change the priority index
                For k = 1 To ETtop
                    If ET(k).PriIdx = i Then
                        ET(k).PriIdx = j
                    ElseIf ET(k).PriIdx = j Then
                        ET(k).PriIdx = i
                    End If
                Next
            End If
        Next i
    End Sub
    '---------------------------------------------------------------------------------
    Private Sub Arguments_Cleanup()
        Dim i As Integer, j As Integer
        For i = 1 To ETtop
            j = ET(i).ArgOf
            If j > 0 Then
                With ET(j).Arg(ET(i).ArgIdx)
                    .Idx = 0
                    .Nome = ""
                End With
            End If
        Next i
    End Sub
    '---------------------------------------------------------------------------------
    Private Function CheckExpo(ByVal SubExpr As String) As Boolean
        Dim s_1 As String, s_2 As String, ls As Integer
        'detect if SubExpr is the mantissa of an expo format number 1.2E+01 , 4E-12, 1.0E-6
        CheckExpo = False
        ls = Len(SubExpr)
        If ls < 2 Then Exit Function
        s_1 = Right(SubExpr, 1)
        s_2 = Left(SubExpr, ls - 1)
        If (UCase(s_1) = "E") And IsNumeric_(s_2) Then CheckExpo = True
    End Function

    Private Function getPrevChar(ByVal i As Integer, ByVal str As String) As String
        If i <= 1 Then
            getPrevChar = ""
        Else
            getPrevChar = Right(Trim(Left(str, i - 1)), 1)
        End If
    End Function

    Private Function CheckSign(ByVal i As Integer, ByVal str As String) As Boolean
        Dim s_1 As String, s_2 As String
        CheckSign = True
        If i <= 1 Then Exit Function
        s_1 = Trim(Left(str, i - 1))
        s_2 = Right(s_1, 1)
        If s_2 = ")" Or s_2 = "]" Or s_2 = "}" Then CheckSign = False
        If s_2 = "(" Or s_2 = "[" Or s_2 = "{" Then CheckSign = True
    End Function
    '-------------------------------------------------------------------------------
    'Search for the condition nodes in the graph appling the logic condition rules
    Private Sub Control_Nodes(ByRef Node_Cond() As Integer, ByRef Node_Switch() As Integer, ByRef Node_max As Integer)
        'mod. 30-6-2004
        Dim n&, i&, j&, k&, p&, count_iter&
        Dim Node_dup As Boolean
        Dim Node_aux() As Integer, Node_aux1() As Integer
        Dim Ns&, Nc&, Level_max&

        n = UBound(ET)
        ReDim Node_Cond(n), Node_Switch(n), Node_aux(n)
        j = 0
        For i = 1 To n
            If InStr(1, " > < = <= >= <> =< =>", ET(i).Fun) > 0 Then
                Node_aux(i) = 2
                'search for duplicate nodes
                Node_dup = False
                For p = 1 To j
                    If Node_Switch(p) = ET(i).ArgOf Then
                        Node_dup = True
                        Exit For
                    End If
                Next
                'apply rule
                If Node_dup Then
                    Node_Cond(p) = Node_Switch(p)
                    Node_Switch(p) = ET(Node_Cond(p)).ArgOf
                    Node_aux(Node_Cond(p)) = 2
                Else
                    j = j + 1
                    Node_Cond(j) = i
                    Node_Switch(j) = ET(i).ArgOf
                End If
            End If
            If Level_max < ET(i).PriLvl Then Level_max = ET(i).PriLvl
        Next i
        Node_max = j
        If Node_max = 0 Then Exit Sub 'no logic function detected
        ReDim Preserve Node_Cond(Node_max), Node_Switch(Node_max)

        For p = 1 To Node_max
            'load control node information
            Nc = Node_Cond(p)
            Ns = Node_Switch(p)
            If ET(Ns).Fun = "*" Then
                ReDim Node_aux1(n)
                For i = 1 To n : Node_aux1(i) = Node_aux(i) : Next i
                'apply the graph-condition-rules to the table
                count_iter = 0
                For k = 1 To n
                    i = k : j = 0
                    Do
                        If Node_aux1(i) = -1 Or ET(i).ArgOf = 0 Then
                            'node k independent
                            Node_aux1(k) = -1
                            Exit Do
                        End If
                        If Node_aux1(i) = 2 Then
                            'assign higher priority to the condition node and its childs
                            ET(k).PriLvl = ET(k).PriLvl + 100
                            Exit Do
                        End If
                        If Node_aux1(i) = 1 Or ET(i).ArgOf = Ns Then
                            'node k dependent
                            Node_aux1(k) = 1
                            ET(k).Cond = Nc
                            Exit Do
                        End If
                        i = ET(i).ArgOf
                        j = j + 1
                    Loop Until j > n
                    count_iter = count_iter + j
                Next k
            End If
        Next p

    End Sub
    '-------------------------------------------------------------------------------
    '[modified 10/02 by Thomas Zeutschler]
    Private Function Eval_(ByRef EvalValue As Double) As Boolean
        Dim a As Double
        Dim b As Double
        Dim ris As Double
        Dim j As Integer
        Dim k As Integer
        Dim pos As Integer
        Dim m As Integer
        Dim n As Integer
        Dim sa As String
        Dim sb As String

        On Error GoTo ErrHandler  '<<< comment for debug  VL 30-8-02
        For j = 1 To ETtop    'Evaluation procedure begins
            k = ET(j).PriIdx
            ris = 0
            With ET(k)
                '--  apply conditioning rule --------------
                If .Cond <> 0 Then If ET(.Cond).Value = 0 Then GoTo ResultHandler
                '------------------------------
                a = .Arg(1).Value
                b = .Arg(2).Value
                Select Case .FunTok
                    Case symPlus : ris = a + b
                    Case symMinus : ris = a - b
                    Case symMul : ris = a * b
                    Case symDiv : ris = a / b
                    Case symPercent : ris = a / 100
                    Case symDivInt : ris = a \ b
                    Case symPov : ris = a ^ b : If a = b And a = 0 Then GoTo ErrHandler '26.7.04 Ricardo Martínez C.
                    Case symNeg : ris = -a
                    Case symAbs : ris = Abs(a)
                    Case symAtn : ris = Atan(a) / CvAngleCoeff
                    Case symCos : ris = Cos(CvAngleCoeff * a)
                    Case symSin : ris = Sin(CvAngleCoeff * a)
                    Case symExp : ris = Exp(a)
                    Case symFix : ris = Fix(a)
                    Case symInt : ris = Int(a)
                    Case symDec : ris = Dec_(a)
                    Case symLn : ris = Log(a)
                    Case symLog : ris = Log(a)    'the same as natural logarithm mod. 15.6.2004
                    Case symLogN : ris = Log(a) / Log(b)
                    Case symRnd : ris = a * Rnd(1)
                    Case symSgn : ris = Sign(a)
                    Case symsqrt : ris = Sqrt(a)
                    Case symCbr : ris = Sign(a) * Abs(a) ^ (1 / 3)
                    Case symTan : ris = Tan(CvAngleCoeff * a)
                    Case symAcos : ris = Acos_(a) / CvAngleCoeff
                    Case symAsin : ris = Asin_(a) / CvAngleCoeff
                    Case symCosh : ris = Cosh_(a)
                    Case symSinh : ris = Sinh_(a)
                    Case symTanh : ris = Tanh_(a)
                    Case symAcosh : ris = Acosh_(a)   '7.10.2003 fix bug (thank to Rodrigo Farinha)
                    Case symAsinh : ris = Asinh_(a)
                    Case symAtanh : ris = Atanh_(a)
                    Case symRoot : ris = MiRoot_(a, b)
                    Case symmod : ris = Mod_(a, b)   'a Mod b  17.10.03 fix VBA bug
                    Case symFact : ris = fact(a)
                    Case symComb : ris = Comb(a, b)
                    Case symPerm : ris = Perm(a, b)
                    Case symGT : ris = -CDbl((a > b))
                    Case symGE : ris = -CDbl(a >= b)
                    Case symLT : ris = -CDbl(a < b)
                    Case symLE : ris = -CDbl(a <= b)
                    Case symEQ : ris = -CDbl(a = b)
                    Case symNE : ris = -CDbl(a <> b)
                    Case symAnd : ris = -CDbl((a <> 0) And (b <> 0))
                    Case symOr : ris = -CDbl((a <> 0) Or (b <> 0))
                    Case symNot : ris = -CDbl(a = 0)
                    Case symXor : ris = -CDbl((a <> 0) Xor (b <> 0)) ' MR 16-01-03 XOR corrected
                    Case symNAnd : ris = -CDbl((a = 0) Or (b = 0))     '
                    Case symNOr : ris = -CDbl((a = 0) And (b = 0))    '
                    Case symNXor : ris = -CDbl((a <> 0) = (b <> 0))    'MR 16-01-03 NXor        '
                    Case symErf : ris = erf_(a)
                    Case symGamma : ris = gamma_(a)
                    Case symGammaln : ris = gammaln_(a)
                    Case symDigamma : ris = digamma_(a)
                    Case symGammaI : ris = GammaInc(a, b)
                    Case symBeta : ris = beta_(a, b)
                    Case symZeta : ris = Zeta_(a)
                    Case symEi : ris = exp_integr(a)
                    Case symCsc : ris = 1 / Sin(CvAngleCoeff * a)
                    Case symSec : ris = 1 / Cos(CvAngleCoeff * a)
                    Case symCot : ris = 1 / Tan(CvAngleCoeff * a)
                    Case symACsc : ris = Asin_(1 / a) / CvAngleCoeff
                    Case symASec : ris = Acos_(1 / a) / CvAngleCoeff
                    Case symACot : ris = PI_ / 2 - Atan(a) / CvAngleCoeff
                    Case symCsch : ris = 1 / Sinh_(a)
                    Case symSech : ris = 1 / Cosh_(a)
                    Case symCoth : ris = 1 / Tanh_(a)
                    Case symACsch : ris = Asinh_(1 / a)
                    Case symASech : ris = Acosh_(1 / a)
                    Case symACoth : ris = Atanh_(1 / a)
                    Case symRad : ris = a / CvAngleCoeff
                    Case symDeg : ris = a / CvAngleCoeff * PI_ / 180
                    Case symGrad : ris = a / CvAngleCoeff * PI_ / 200
                    Case symRound : ris = round_(a, b)
                    Case symRight : ris = b
                    Case symDPoiss : ris = DPoisson(a, b)
                    Case symCPoiss : ris = CPoisson(a, b)
                    Case symEin : ris = expn_integr(a, b)
                    Case symSi : ris = SinIntegral(a)
                    Case symCi : ris = CosIntegral(a)
                    Case symFresS : ris = Fresnel_sin(a)
                    Case symFresC : ris = Fresnel_cos(a)
                    Case symBessJ : ris = BesselJ(a, b)
                    Case symBessY : ris = BesselY(a, b)
                    Case symBessK : ris = BesselK(a, b)
                    Case symBessI : ris = BesselI(a, b)
                    Case symJ0 : ris = BesselJ(a, 0)
                    Case symY0 : ris = BesselY(a, 0)
                    Case symI0 : ris = BesselI(a, 0)
                    Case symK0 : ris = BesselK(a, 0)
                    Case symPolyLe : ris = Poly_Legendre(a, b)
                    Case symPolyLa : ris = Poly_Laguerre(a, b)
                    Case symPolyHe : ris = Poly_Hermite(a, b)
                    Case symPolyCh : ris = Poly_Chebycev(a, b)
                    Case symAiryA : ris = Airy_A(a)
                    Case symAiryB : ris = Airy_B(a)
                    Case symEllipt1 : ris = IElliptic_Int1(a, CvAngleCoeff * b)
                    Case symEllipt2 : ris = IElliptic_Int2(a, CvAngleCoeff * b)
                    Case symWtri : ris = WAVE_TRI(a, b)
                    Case symWsqrt : ris = WAVE_SQR(a, b)
                    Case symWsaw : ris = WAVE_SAW(a, b)
                    Case symWraise : ris = WAVE_RAISE(a, b)
                    Case symWparab : ris = WAVE_PARAB(a, b)
                    Case symStep : ris = Step_(a, b)
                        ' > Berend 20041216
                        ' > not clear for me EAC 20090517
                    Case symYear : ris = Year(Date.FromOADate(a))
                    Case symMonth : ris = Month(Date.FromOADate(a))
                    Case symDay : ris = Day(Date.FromOADate(a))
                    Case symHour : ris = Hour(Date.FromOADate(a))
                    Case symMinute : ris = Minute(Date.FromOADate(a))
                    Case symSecond : ris = Second(Date.FromOADate(a))
                        ' < Berend 20041216
                    Case Is > HFOffset
                        ris = EvalMulti_(k)  'multi-variable function
                    Case Else
                        ErrMsg = getMsg(13, .FunTok) '"Function <" & .FunTok & "> missing?"
                        Exit Function
                End Select
                If .Sign = -1 Then ris = -ris 'change function sign (7-1-04)
ResultHandler:
                .Value = ris
                m = .ArgOf
                n = .ArgIdx
                If m = 0 Or n = 0 Then Exit For
                ET(m).Arg(n).Value = ris
            End With
        Next j
        EvalValue = ET(k).Value
        Eval_ = True
        Exit Function
ErrHandler:
        ErrPos = ET(k).PosInExpr
        If ET(k).FunTok < HFOffset Then
            'build the error msg for functions having 1 or 2 fixed arguments
            sa = a : sb = b
            If DP_SET Then  'force the decimal point
                sa = Replace(a, ",", ".")
                sb = Replace(b, ",", ".")
            End If
            If ET(k).ArgTop = 1 Then
                ErrMsg = getMsg(14, ET(k).Fun, sa, ErrPos)
            ElseIf ET(k).ArgTop = 2 Then
                If InList(ET(k).Fun, Fun2V) Then
                    ErrMsg = getMsg(15, ET(k).Fun, sa, sb, ErrPos)
                Else
                    ErrMsg = getMsg(16, sa, ET(k).Fun, sb, ErrPos)
                End If
            End If
        Else
            'build the error msg for functions having multi-arguments
            For j = 1 To ET(k).ArgTop
                If j > 1 Then ErrMsg = ErrMsg & ArgSep
                sa = ET(k).Arg(j).Value
                If DP_SET Then sa = Replace(sa, ",", ".")
                ErrMsg = ErrMsg & sa
            Next j
            ErrMsg = getMsg(17, ET(k).Fun, ErrMsg, ErrPos)
        End If
        EvalValue = 0
        Eval_ = False
    End Function

    Private Function EvalMulti_(ByVal k As Integer) As Double
        'evaluate multi-variable functions.
        'mod. 20.10.2006 - added variable arguments functions. (Thanks to Mirko Sartori)
        Dim ris As Double
        Dim i As Integer
        Dim x() As Double

        With ET(k)
            If .FunTok < (HFOffset + 100) Then
                'section of fixed arguments functions
                Select Case .FunTok
                    Case symDnorm
                        ris = DNormal(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symCnorm
                        ris = CNormal(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symDBinom
                        ris = DBinomial(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symCBinom
                        ris = CBinomial(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symHypGeo
                        ris = Hypergeom(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value, .Arg(4).Value)
                    Case symBetaI
                        ris = BetaInc(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symClip
                        ris = Clip(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWrect
                        ris = WAVE_RECT(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWtrapez
                        ris = WAVE_TRAPEZ(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWlin
                        ris = WAVE_LIN(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWpulse
                        ris = WAVE_PULSE(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWsteps
                        ris = WAVE_STEPS(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWexp
                        ris = WAVE_EXP(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWexpb
                        ris = WAVE_EXPB(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWpulsef
                        ris = WAVE_PULSEF(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWripple
                        ris = WAVE_RIPPLE(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symWring
                        ris = WAVE_RING(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value, .Arg(4).Value)
                    Case symWam
                        ris = WAVE_AM(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value, .Arg(4).Value)
                    Case symWfm
                        ris = WAVE_FM(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value, .Arg(4).Value)
                        ' > Berend 20041216
                    Case symDateSerial
                        'ris = DateSerial(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                    Case symTimeSerial
                        'ris = TimeSerial(.Arg(1).Value, .Arg(2).Value, .Arg(3).Value)
                        ' < Berend 20041216
                    Case Else
                        ErrMsg = getMsg(13, .FunTok) '"Function <" & .FunTok & "> missing?"  'VL
                        ris = "" 'rise an error
                End Select

            Else
                'section of variable arguments functions
                ReDim x(0 To .ArgTop)
                For i = 1 To .ArgTop : x(i) = .Arg(i).Value : Next i
                Select Case .FunTok
                    Case symMin
                        ris = min_n(x)
                    Case symMax
                        ris = max_n(x)
                    Case symSum
                        ris = sum_(x)
                    Case symMean
                        ris = mean_(x)
                    Case symMeanq
                        ris = meanq_(x)
                    Case symMeang
                        ris = meang_(x)
                    Case symVar
                        ris = var_(x)
                    Case symVarp
                        ris = varp_(x)
                    Case symStdev
                        ris = stdev_(x)
                    Case symStdevp
                        ris = stdevp_(x)
                    Case symMcd
                        ris = mcd_(x)
                    Case symMcm
                        ris = mcm_(x)
                    Case Else
                        ErrMsg = getMsg(13, .FunTok) '"Function <" & .FunTok & "> missing?"  'VL
                        ris = "" 'rise an error
                End Select
            End If
        End With
        EvalMulti_ = ris
    End Function
    '-------------------------------------------------------------------------------
    ' Check if all variable has been assigned
    Private Function VarEmpty() As Boolean
        Dim i As Integer
        If VTtop = iInit Then
            VarEmpty = False
        Else
            VarEmpty = True
            For i = 1 To VTtop
                If VT(i).Init = False Then Exit For
            Next i
            ErrMsg = getMsg(18, VT(i).Nome)   '"Variable < " & VT(i).Nome & " > not assigned"
            ErrPos = 1
        End If
    End Function
    '-------------------------------------------------------------------------------
    ' Assignes a value to symbolic Vars
    Private Sub SubstVars()
        Dim i As Integer, j As Integer

        For i = 1 To ETtop
            For j = 1 To ET(i).ArgTop
                With ET(i).Arg(j)
                    If .Idx <> 0 Then .Value = .Sign * VT(.Idx).Value
                End With
            Next
        Next
    End Sub
    '-------------------------------------------------------------------------------
    ' search if var already exists in table, if not add it
    Private Sub StoreVar(ByVal SubExpr As String, ByVal LastArg As Boolean, ByVal Sign As Integer)
        Dim VTIdx As Integer
        Dim ArgIdx As Integer
        Dim Found As Boolean

        Found = False
        For VTIdx = 1 To VTtop
            'If VT(VTIdx).Nome = SubExpr Then
            If LCase$(VT(VTIdx).Nome) = LCase$(SubExpr) Then  '20.12.2004 fix bug Variable Uppercase. thanks to André Hendriks
                Found = True
                Exit For
            End If
        Next
        If Not Found Then
            VTtop = VTtop + 1     'new variable
            If VTtop > HiVT Then  'to many Vars
                Exit Sub
            End If
            VT(VTtop).Nome = SubExpr
            'add a new variable to the object collection (bb 6-1-04)
            VarsTbl.Add(VTtop, SubExpr)
        End If
        If LastArg Then
            ArgIdx = ET(ETtop).ArgTop
            If ArgIdx > 2 Then ArgIdx = 2
        Else
            ArgIdx = 1
        End If
        With ET(ETtop).Arg(ArgIdx)
            .Nome = SubExpr
            .Idx = VTIdx
            .Sign = Sign
        End With
    End Sub
    '-------------------------------------------------------------------------------
    ' get function token '[added 10/02 by Thomas Zeutschler]
    Private Function GetFunTok(ByVal FunTok As String) As Integer
        Select Case LCase(FunTok)
            Case "+" : GetFunTok = symPlus
            Case "-" : GetFunTok = symMinus
            Case "*" : GetFunTok = symMul
            Case "/" : GetFunTok = symDiv
            Case "%" : GetFunTok = symPercent
            Case "\" : GetFunTok = symDivInt
            Case "^" : GetFunTok = symPov
            Case "neg" : GetFunTok = symNeg
            Case "abs" : GetFunTok = symAbs
            Case "atn" : GetFunTok = symAtn
            Case "atan" : GetFunTok = symAtn   '30.3.04 VL
            Case "cos" : GetFunTok = symCos
            Case "sin" : GetFunTok = symSin
            Case "exp" : GetFunTok = symExp
            Case "fix" : GetFunTok = symFix
            Case "int" : GetFunTok = symInt
            Case "dec" : GetFunTok = symDec
            Case "ln" : GetFunTok = symLn
            Case "log" : GetFunTok = symLog
            Case "logn" : GetFunTok = symLogN
            Case "rnd" : GetFunTok = symRnd
            Case "sgn" : GetFunTok = symSgn
            Case "sqr" : GetFunTok = symsqrt
            Case "cbr" : GetFunTok = symCbr
            Case "tan" : GetFunTok = symTan
            Case "acos" : GetFunTok = symAcos
            Case "asin" : GetFunTok = symAsin
            Case "cosh" : GetFunTok = symCosh
            Case "sinh" : GetFunTok = symSinh
            Case "tanh" : GetFunTok = symTanh
            Case "acosh" : GetFunTok = symAcosh
            Case "asinh" : GetFunTok = symAsinh
            Case "atanh" : GetFunTok = symAtanh
            Case "root" : GetFunTok = symRoot
            Case "mod" : GetFunTok = symmod
            Case "fact", "!" : GetFunTok = symFact
            Case "comb" : GetFunTok = symComb
            Case "perm" : GetFunTok = symPerm
            Case "min" : GetFunTok = symMin
            Case "max" : GetFunTok = symMax
            Case "mcd", "gcd" : GetFunTok = symMcd
            Case "mcm", "lcm" : GetFunTok = symMcm
            Case ">" : GetFunTok = symGT
            Case ">=", "=>" : GetFunTok = symGE
            Case "<" : GetFunTok = symLT
            Case "<=", "=<" : GetFunTok = symLE
            Case "=" : GetFunTok = symEQ
            Case "<>" : GetFunTok = symNE
            Case "and" : GetFunTok = symAnd
            Case "or" : GetFunTok = symOr
            Case "not" : GetFunTok = symNot
            Case "xor" : GetFunTok = symXor
            Case "nand" : GetFunTok = symNAnd
            Case "nor" : GetFunTok = symNOr
            Case "nxor" : GetFunTok = symNXor
            Case "erf" : GetFunTok = symErf
            Case "gamma" : GetFunTok = symGamma
            Case "gammaln" : GetFunTok = symGammaln
            Case "digamma" : GetFunTok = symDigamma
            Case "gammai" : GetFunTok = symGammaI
            Case "beta" : GetFunTok = symBeta
            Case "zeta" : GetFunTok = symZeta
            Case "ei" : GetFunTok = symEi
            Case "ein" : GetFunTok = symEin
            Case "csc" : GetFunTok = symCsc
            Case "sec" : GetFunTok = symSec
            Case "cot" : GetFunTok = symCot
            Case "acsc" : GetFunTok = symACsc
            Case "asec" : GetFunTok = symASec
            Case "acot" : GetFunTok = symACot
            Case "csch" : GetFunTok = symCsch
            Case "sech" : GetFunTok = symSech
            Case "coth" : GetFunTok = symCoth
            Case "acsch" : GetFunTok = symACsch
            Case "asech" : GetFunTok = symASech
            Case "acoth" : GetFunTok = symACoth
            Case "rad" : GetFunTok = symRad
            Case "deg" : GetFunTok = symDeg
            Case "grad" : GetFunTok = symGrad
            Case "round" : GetFunTok = symRound
            Case "dnorm" : GetFunTok = symDnorm
            Case "cnorm" : GetFunTok = symCnorm
            Case "dbinom" : GetFunTok = symDBinom
            Case "cbinom" : GetFunTok = symCBinom
            Case "dpoisson" : GetFunTok = symDPoiss
            Case "cpoisson" : GetFunTok = symCPoiss
            Case "si" : GetFunTok = symSi
            Case "ci" : GetFunTok = symCi
            Case "psi" : GetFunTok = symDigamma
            Case "fresnels" : GetFunTok = symFresS
            Case "fresnelc" : GetFunTok = symFresC
            Case "besselj" : GetFunTok = symBessJ
            Case "besseli" : GetFunTok = symBessI
            Case "besselk" : GetFunTok = symBessK
            Case "bessely" : GetFunTok = symBessY
            Case "j0" : GetFunTok = symJ0
            Case "y0" : GetFunTok = symY0
            Case "i0" : GetFunTok = symI0
            Case "k0" : GetFunTok = symK0
            Case "hypgeom" : GetFunTok = symHypGeo
            Case "betai" : GetFunTok = symBetaI
            Case "polyle" : GetFunTok = symPolyLe
            Case "polyhe" : GetFunTok = symPolyHe
            Case "polyla" : GetFunTok = symPolyLa
            Case "polych" : GetFunTok = symPolyCh
            Case "airya" : GetFunTok = symAiryA
            Case "airyb" : GetFunTok = symAiryB
            Case "elli1" : GetFunTok = symEllipt1
            Case "elli2" : GetFunTok = symEllipt2
            Case "clip" : GetFunTok = symClip
            Case "wtri" : GetFunTok = symWtri
            Case "wsqrt" : GetFunTok = symWsqrt
            Case "wsaw" : GetFunTok = symWsaw
            Case "wraise" : GetFunTok = symWraise
            Case "wparab" : GetFunTok = symWparab
            Case "wrect" : GetFunTok = symWrect
            Case "wtrapez" : GetFunTok = symWtrapez
            Case "wlin" : GetFunTok = symWlin
            Case "wpulse" : GetFunTok = symWpulse
            Case "wsteps" : GetFunTok = symWsteps
            Case "wexp" : GetFunTok = symWexp
            Case "wexpb" : GetFunTok = symWexpb
            Case "wpulsef" : GetFunTok = symWpulsef
            Case "wripple" : GetFunTok = symWripple
            Case "wring" : GetFunTok = symWring
            Case "wam" : GetFunTok = symWam
            Case "wfm" : GetFunTok = symWfm
            Case "@right" : GetFunTok = symRight
                ' > Berend 20041216
            Case "year" : GetFunTok = symYear
            Case "month" : GetFunTok = symMonth
            Case "day" : GetFunTok = symDay
            Case "hour" : GetFunTok = symHour
            Case "minute" : GetFunTok = symMinute
            Case "second" : GetFunTok = symSecond
            Case "dateserial" : GetFunTok = symDateSerial
            Case "timeserial" : GetFunTok = symTimeSerial
                ' < Berend 20041216
            Case "mean" : GetFunTok = symMean
            Case "sum" : GetFunTok = symSum
            Case "meanq" : GetFunTok = symMeanq
            Case "meang" : GetFunTok = symMeang
            Case "var" : GetFunTok = symVar
            Case "varp" : GetFunTok = symVarp
            Case "stdev" : GetFunTok = symStdev
            Case "stdevp" : GetFunTok = symStdevp
            Case "step" : GetFunTok = symStep
            Case Else
                GetFunTok = symARGUMENT
        End Select
    End Function
    '-------------------------------------------------------------------------------
    ' translate egu to multiplication factor
    '  accepts a string contains a measure like "2ms" ,"234.12Mhz", "0.1uF" , 12Km , etc
    '  [relaxed parsing: allow space between number and unit and allow numbers without units]
    Private Function convEGU(ByVal strSource As String, ByRef retval As Double) As Boolean
        Dim EguStr As String
        Dim EguChar As String
        Dim EguStart As Integer
        Dim EguLen As Integer
        Dim EguMult As String
        Dim EguCoeff As Double
        Dim EguFact As Integer
        Dim EguSym As String
        Dim EguBase As Double

        'check flag unit conversion  23-2-05
        If Unit_conv = False Then
            convEGU = False
            Exit Function
        End If

        EguStr = strSource      'trim niet nodig. alle spaties zijn weg
        EguLen = Len(EguStr)
        For EguStart = 1 To EguLen
            EguChar = Mid(EguStr, EguStart, 1)  'fix Expo number bug. 25.1.03 VL
            If Not IsNumeric_(EguChar) Then
                Select Case EguChar
                    Case "+", "-", DecSep
                        'continue
                    Case "E", "e"
                        EguChar = Mid(EguStr, EguStart + 1, 1) 'check next char
                        If Not (EguChar = "+" Or EguChar = "-" Or IsNumeric_(EguChar)) Then Exit For
                    Case Else
                        If IsLetter(EguChar) Then
                            Exit For
                        Else
                            convEGU = False : Exit Function
                        End If
                End Select
            End If
        Next
        '
        If EguStart = 1 Or EguStart > EguLen Then
            convEGU = False
            Exit Function
        End If
        '
        If DP_SET Then
            EguCoeff = Val(Left(EguStr, EguStart - 1))   'get number
        Else
            EguCoeff = CDbl(Left(EguStr, EguStart - 1))  '23.10.06
        End If
        EguStr = Mid(EguStr, EguStart)          'extract literal substring
        EguLen = Len(EguStr)
        If EguLen > 1 Then                      'extract multiply factor
            EguMult = Left(EguStr, 1)
            Select Case EguMult
                Case "p" : EguFact = -12
                Case "n" : EguFact = -9
                Case "u" : EguFact = -6      '
#If CODPAGE = 0 Then
                Case "µ" : EguFact = -6      '30.3.04 VL (comment this line for chinese/japanese VB version)
#End If
                Case "m" : EguFact = -3
                Case "c" : EguFact = -2
                Case "k" : EguFact = 3       '14.2.03 VL
                Case "M" : EguFact = 6
                Case "G" : EguFact = 9
                Case "T" : EguFact = 12
                Case Else : EguFact = 0
            End Select
        Else
            EguFact = 0
        End If

        If EguFact <> 0 Then       'extract um symbol
            EguSym = Mid(EguStr, 2)
        Else
            EguSym = EguStr          ' MR 16-01-03 enable units without factors
        End If

        Select Case EguSym         'check if um exists and compute numeric value
            Case "s" : EguBase = 1                 'second
            Case "Hz" : EguBase = 1                 'frequency
            Case "m" : EguBase = 1                 'meter
            Case "g" : EguBase = 0.001             'gramme
            Case "rad", "Rad", "RAD" : EguBase = 1   'radiant  '18-10-02 VL
            Case "S" : EguBase = 1                 'siemens
            Case "V" : EguBase = 1                 'volt
            Case "A" : EguBase = 1                 'ampere
            Case "W" : EguBase = 1                 'watt
            Case "F" : EguBase = 1                 'farad
            Case "bar" : EguBase = 1                 'bar
            Case "Pa" : EguBase = 1                 'pascal
            Case "Nm" : EguBase = 1                 'newtonmeter
            Case "Ohm", "ohm" : EguBase = 1          'ohm     '18-10-02 VL
            Case Else
                'ErrMsg = "unknown unit of measure: " + EguSym
                convEGU = False
                Exit Function
        End Select
        retval = EguCoeff * EguBase * 10 ^ EguFact   'finally compute the numeric value
        convEGU = True
    End Function
    '-------------------------------------------------------------------------------
    'check if it is a letter
    Private Function IsLetter(ByVal chr As String) As Boolean
        Dim code As Integer
        code = Asc(chr)
        IsLetter = (65 <= code And code <= 90) Or (97 <= code And code <= 122) Or chr = "_"
    End Function
    '-------------------------------------------------------------------------------
    'check if it is a variable name
    Private Function IsVariable(ByVal str As String) As Boolean
        Dim i As Integer, ch As String
        If IsLetter(Left(str, 1)) Then
            For i = 2 To Len(str)
                ch = Mid(str, i, 1)
                If Not IsLetter(ch) Then If Not IsDigit(ch) Then Exit Function
            Next i
            IsVariable = True
        End If
    End Function
    '-------------------------------------------------------------------------------
    'check if it is a digit
    Private Function IsDigit(ByVal chr As String) As Boolean
        Dim code As Integer
        code = Asc(chr)
        IsDigit = (48 <= code And code <= 57)
    End Function
    '-------------------------------------------------------------------------------
    'check for an expression to occur in a list
    Private Function InList(ByVal strElem As String, ByVal strList As String) As Boolean
        Dim lstrElem As String
        Dim lstrList As String

        lstrList = " " & strList & " "
        lstrElem = " " & strElem & " "
        InList = InStr(1, lstrList, lstrElem, vbTextCompare) > 0
    End Function
    '-------------------------------------------------------------------------------
    ' translate a symbolic Constant to its double value
    Private Function convSymbConst(ByVal strSource As String, ByRef retval As Double) As Boolean
        Dim CostToken As String
        Dim SymbConst As String
        CostToken = "#"
        convSymbConst = False : ErrMsg = "" : ErrId = 0
        'check if string is "pi" only for compatibility with previous release.
        If LCase(strSource) = "pi" Then strSource = strSource & CostToken
        If Right(strSource, 1) <> CostToken Then Exit Function
        retval = 0
        SymbConst = Left(strSource, Len(strSource) - 1)
        Select Case SymbConst
            Case "pi", "PI" : retval = PI_              'pi-greek
            Case "pi2" : retval = PI_ / 2                'pi-greek/2
            Case "pi3" : retval = PI_ / 3                'pi-greek/3
            Case "pi4" : retval = PI_ / 4                'pi-greek/4
            Case "e" : retval = 2.71828182845905       'Euler-Napier constant
            Case "eu" : retval = 0.577215664901533      'Euler-Mascheroni constant
            Case "phi" : retval = 1.61803398874989       'golden ratio
            Case "g" : retval = 9.80665                'Acceleration due to gravity
            Case "G" : retval = 6.672 * 10 ^ -11       'Gravitational constant
            Case "R" : retval = 8.31451                'Gas constant
            Case "eps" : retval = 8.854187817 * 10 ^ -12 'Permittivity of vacuum
            Case "mu" : retval = 12.566370614 * 10 ^ -7 'Permeability of vacuum
            Case "c" : retval = 2.99792458 * 10 ^ 8    'Speed of light
            Case "q" : retval = 1.60217733 * 10 ^ -19  'Elementary charge
            Case "me" : retval = 9.1093897 * 10 ^ -31   'Electron rest mass
            Case "mp" : retval = 1.6726231 * 10 ^ -27   'Proton rest mass
            Case "mn" : retval = 1.6749286 * 10 ^ -27   'Neutron rest mass
            Case "K" : retval = 1.380658 * 10 ^ -23    'Boltzmann constant
            Case "h" : retval = 6.6260755 * 10 ^ -34   'Planck constant
            Case "A" : retval = 6.0221367 * 10 ^ 23    'Avogadro number
            Case Else
                ' > Berend 20041216 - support intrinsic date/time values
                Select Case UCase$(SymbConst)
                    Case "DATE"  'or date
                        'retval = CDbl(Date)
                    Case "TIME"  'or time
                        'retval = CDbl(Time)
                    Case "NOW"   'or now
                        'retval = CDbl(Now)
                    Case Else
                        ErrMsg = getMsg(19, SymbConst)  ' "Constant unknown: " & SymbConst
                End Select
                ' < Berend 20041216
        End Select
        convSymbConst = True
    End Function
    '-------------------------------------------------------------------------------
    'break the variable string into the name and its sign (if any). Es -x
    Private Sub Catch_Sign(ByRef str As String, ByRef Sign As Integer)
        Dim s As String, VarName As String
        Sign = 1
        s = Left(str, 1)
        If s = "-" Or s = "+" Then
            str = Right(str, Len(str) - 1)
            If s = "-" Then Sign = -Sign
        End If
    End Sub
    'return the current environment setting for decimal separator
    'about 2-3 us, that is 20 times faster than Application.International(xlDecimalSeparator)
    Private Function Decimal_Point_Is()
        Decimal_Point_Is = Mid(CStr(1 / 2), 2, 1)
    End Function

    Private Function Acos_(ByVal a As Double) As Double
        If a = 1 Then
            Acos_ = 0
        ElseIf a = -1 Then
            Acos_ = PI_
        Else
            Acos_ = Atan(-a / Sqrt(-a * a + 1)) + 2 * Atan(1)
        End If
    End Function

    Private Function Asin_(ByVal a As Double) As Double
        If Abs(a) = 1 Then
            Asin_ = Sign(a) * PI_ / 2
        Else
            Asin_ = Atan(a / Sqrt(-a * a + 1))
        End If
    End Function

    Private Function Cosh_(ByVal a As Double) As Double
        Cosh_ = (Exp(a) + Exp(-a)) / 2
    End Function

    Private Function Sinh_(ByVal a As Double) As Double
        Sinh_ = (Exp(a) - Exp(-a)) / 2
    End Function

    Private Function Tanh_(ByVal a As Double) As Double
        Tanh_ = (Exp(a) - Exp(-a)) / (Exp(a) + Exp(-a))
    End Function

    Private Function Acosh_(ByVal a As Double) As Double
        Acosh_ = Log(a + Sqrt(a * a - 1))
    End Function

    Private Function Asinh_(ByVal a As Double) As Double
        Asinh_ = Log(a + Sqrt(a * a + 1))
    End Function

    Private Function Atanh_(ByVal a As Double) As Double
        Atanh_ = Log((1 + a) / (1 - a)) / 2  'bug 3-1-2003 VL
    End Function

    Private Function round_(ByVal x As Double, ByVal n As Double) As Double
        Dim xi As Double, xd As Double, b As Double, d As Integer
        d = CheckInt(n)
        b = 10 ^ d
        x = x * b
        xi = Int(x)
        xd = x - xi
        If xd > 0.5 Then xi = xi + 1
        round_ = xi / b
    End Function

    '-------------------------------------------------------------------------------
    ' calculate Factorial  (bug overflow for n > 12, 8-7-02 VL)
    Private Function fact(ByVal n As Double) As Double
        Dim p As Double, i As Integer, m As Integer
        '7.10.2003 thanks to Rodrigo Farinha
        If n < 0 Then
            fact = ""  'raise an error
        Else
            m = CheckInt(n)
            p = 1
            For i = 1 To Int(n)
                p = p * i
            Next
            fact = p
        End If
    End Function
    '-------------------------------------------------------------------------------
    'MCM between two integer numbers
    Private Function mcm_2(ByVal a As Double, ByVal b As Double) As Double
        Dim x As Integer, y As Integer
        If a < 0 Or b < 0 Then y = "" 'raises in error
        y = CheckInt(Abs(a))
        x = CheckInt(Abs(b))
        mcm_2 = x * y / mcd_2(x, y)
    End Function
    '-------------------------------------------------------------------------------
    'MCM of n-numbers
    Private Function mcm_(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        ris = x(1)
        For i = 2 To n
            ris = mcm_2(ris, x(i))
        Next i
        mcm_ = ris
    End Function
    '-------------------------------------------------------------------------------
    'MCD between two integer numbers
    Private Function mcd_2(ByVal a As Double, ByVal b As Double) As Double
        Dim x As Integer, y As Integer, r As Integer
        If a < 0 Or b < 0 Then y = "" 'raises in error
        y = CheckInt(a)
        x = CheckInt(b)
        Do Until x = 0
            r = y Mod x
            y = x
            x = r
        Loop
        mcd_2 = y
    End Function
    '-------------------------------------------------------------------------------
    'MCD of n-numbers
    Private Function mcd_(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        ris = x(1)
        For i = 2 To n
            ris = mcd_2(ris, x(i))
        Next i
        mcd_ = ris
    End Function
    '-------------------------------------------------------------------------------
    ' combinations n objects, k classes
    Private Function Comb(ByVal a As Double, ByVal b As Double) As Double
        Dim n As Integer, k As Integer, y As Double, i As Integer

        If a < 0 Or b < 0 Then y = "" 'raises in error
        n = CheckInt(a)
        k = CheckInt(b)
        If n < 1 Or k < 1 Or k > n Then Comb = 0 : Exit Function 'mod. 1.4.04 VL
        If k = n Then Comb = 1 : Exit Function
        y = n
        If k > Int(n / 2) Then k = n - k
        For i = 2 To k
            y = y * (n + 1 - i) / i
        Next i
        Comb = y
    End Function
    '-------------------------------------------------------------------------------
    ' Permuations n objects, k classes
    Private Function Perm(ByVal a As Double, ByVal b As Double) As Double
        Dim n As Integer, k As Integer, y As Double, i As Integer

        If a < 0 Or b < 0 Then y = "" 'raises in error
        n = CheckInt(a)
        k = CheckInt(b)
        If n < 1 Or k < 1 Or k > n Then Perm = 0 : Exit Function
        y = n
        For i = 2 To k
            y = y * (n + 1 - i)
        Next i
        Perm = y
    End Function
    '-------------------------------------------------------------------------------
    'max value of n-numbers
    Private Function max_n(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        ris = x(1)
        For i = 2 To n
            ris = max_(ris, x(i))
        Next i
        max_n = ris
    End Function
    '-------------------------------------------------------------------------------
    ' max value of 2 numbers
    Private Function max_(ByVal a As Double, ByVal b As Double) As Double
        If a > b Then max_ = a Else max_ = b
    End Function
    '-------------------------------------------------------------------------------
    'min value of n-numbers
    Private Function min_n(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        ris = x(1)
        For i = 2 To n
            ris = min_(ris, x(i))
        Next i
        min_n = ris
    End Function
    '-------------------------------------------------------------------------------
    ' min value of 2 numbers
    Private Function min_(ByVal a As Double, ByVal b As Double) As Double
        If a < b Then min_ = a Else min_ = b
    End Function
    '-------------------------------------------------------------------------------
    ' count number of abs sybol sets in formula
    Private Function NabsCount(ByVal s As String) As Integer
        Dim n As Integer, p As Integer
        n = 0
        p = InStr(1, s, "|")
        Do While p > 0
            p = p + 1
            n = n + 1
            p = InStr(p, s, "|")
        Loop
        NabsCount = n
    End Function

    Private Function erf_(ByVal x As Double) As Double
        Dim y As Double
        Call Herf(x, y)
        erf_ = y
    End Function
    '-------------------------------------------------------------------------------
    ' gamma function  22.2.05   fix bug for x<0
    Private Function gamma_(ByVal x As Double) As Double
        Dim mantissa As Double, Expo As Double, z As Double
        Dim t As Double, y As Double, e As Integer
        If x <= 0 And x - Int(x) = 0 Then 'negative integer
            gamma_ = "?" : Exit Function
        End If
        z = Abs(x)
        gamma_split(z, mantissa, Expo)
        If x < 0 Then
            t = z * Sin(PI_ * z)
            y = -PI_ / (mantissa * t)
            e = Int(Log(Abs(y)) / Log(10.0#))
            mantissa = y * 10 ^ -e
            Expo = e - Expo
        End If
        gamma_ = mantissa * 10 ^ Expo
    End Function
    '-------------------------------------------------------------------------------
    ' logarithm gamma function
    Private Function gammaln_(ByVal x As Double) As Double
        Dim mantissa As Double, Expo As Double
        gamma_split(x, mantissa, Expo)
        gammaln_ = Log(mantissa) + Expo * Log(10)
    End Function

    Private Function digamma_(ByVal x As Double) As Double
        ' digamma function
        Dim y As Double
        Call HDigamma(x, y)
        digamma_ = y
    End Function

    Private Function beta_(ByVal z As Double, ByVal w As Double) As Double
        ' beta function
        Dim y
        Call HBeta(z, w, y)
        beta_ = y
    End Function

    Private Function Zeta_(ByVal x As Double) As Double
        ' Riemman's zeta function
        Dim y As Double
        Call HZeta(x, y)
        Zeta_ = y
    End Function

    Private Function exp_integr(ByVal x As Double) As Double
        ' exponential integral Ei(x) for x >0.
        Dim y As Double
        Call Hexp_integr(x, y)
        exp_integr = y
    End Function

    Private Function cvDegree(ByVal DMS As String, ByRef angle As Double, Optional ByRef sMsg As String = "") As Boolean
        'converts a string dd°mm'ss" (degrees, minutes, seconds) into a decimal-degree angle
        'mod 16.12.2004
        Dim p1&, p2&, p3&
        Dim A1&, A2&, A3&
        Dim B1&, b2&, b3&
        Dim s1$, s2$, s3$
        Dim dd As Double, mm As Double, ss As Double
        Dim sum_a&, sum_b&, i&

        'check flag dms conversion  23.2.05
        If DMS_conv = False Then
            cvDegree = False
            Exit Function
        End If

        angle = 0
        sMsg = ""
        DMS = Trim(DMS)
        '#If CODPAGE = 0 Then
        'A1 = InStr(1, DMS, "°") ' degrees °
        'A2 = InStr(1, DMS, "'")  ' minutes '
        'A3 = InStr(1, DMS, """")  ' seconds "
        '#End If
        sum_a = A1 + A2 + A3
        B1 = InStr(1, DMS, "d") ' degrees °
        b2 = InStr(1, DMS, "m")  ' minutes '
        b3 = InStr(1, DMS, "s")  ' seconds "
        sum_b = B1 + b2 + b3

        If sum_a > 0 And sum_b = 0 Then
            p1 = A1 : p2 = A2 : p3 = A3
        ElseIf sum_a = 0 And sum_b > 0 Then
            p1 = B1 : p2 = b2 : p3 = b3
        Else
            GoTo Error_Handler_False  'no mixed format allowed
        End If
        If p1 = 0 Then GoTo Error_Handler_False
        If p2 = 0 Then p2 = p1
        On Error Resume Next
        s1 = Mid(DMS, 1, p1 - 1)
        s2 = Mid(DMS, p1 + 1, p2 - p1 - 1)
        s3 = Mid(DMS, p2 + 1, p3 - p2 - 1)
        If s3 = "" And p2 = Len(DMS) Then s3 = "0"
        On Error GoTo 0
        i = 0
        If Not IsNumeric_(s1) Then i = i + 1
        If Not IsNumeric_(s2) Then i = i + 1
        If Not IsNumeric_(s3) Then i = i + 1
        If i = 1 Then GoTo Error_Handler_True 'only one error
        If i > 1 Then GoTo Error_Handler_False 'too many errors
        If p3 > 0 And p3 < Len(DMS) Then GoTo Error_Handler_True

        dd = CDbl(s1)
        mm = CDbl(s2)
        ss = CDbl(s3)

        If mm > 60 Or ss > 60 Then GoTo Error_Handler_True

        angle = dd + (mm + ss / 60) / 60
        cvDegree = True
        Exit Function
Error_Handler_True:
        cvDegree = True
        sMsg = getMsg(21) '"Wrong DMS format"
        Exit Function
Error_Handler_False:
        cvDegree = False
        sMsg = getMsg(22) '"No DMS format"
    End Function

    Private Function IsNumeric_(ByVal x As String) As Boolean
        'numeric check, dependent or independent from international system setting
        'mod. by Ricardo Martínez C.
        '21.10.2006
        Dim i As Integer
        If DecSep = "." Then
            'the decimal separator is the period (.)
            IsNumeric_ = False
            If InStr(1, x, ",") > 0 Then Exit Function 'Comma is not allowed as decimal separator.
            If InStr(1, x, "d", vbTextCompare) > 0 Then Exit Function ' bug 85d5 = 8.5e+6 thanks to PJ Weng  12.6.2004
            i = InStr(1, x, DecSep)
            If i > 0 Then If InStr(i + 1, x, DecSep) > 0 Then Exit Function 'Too many periods.
            If i = 1 And Len(x) > 1 Then x = "0" & x 'Let ".25" = "0.25"
            IsNumeric_ = IsNumeric(x)
        Else
            'the decimal separator is the comma (,)
            IsNumeric_ = False
            If InStr(1, x, ".") > 0 Then Exit Function 'point is not allowed as decimal separator.
            If InStr(1, x, "d", vbTextCompare) > 0 Then Exit Function ' bug 85d5 = 8.5e+6 thanks to PJ Weng  12.6.2004
            i = InStr(1, x, DecSep)
            If i > 0 Then If InStr(i + 1, x, DecSep) > 0 Then Exit Function 'Too many commas.
            If i = 1 And Len(x) > 1 Then x = "0" & x 'Let ",25" = "0,25"
            IsNumeric_ = IsNumeric(x)
        End If
    End Function

    Private Function MiRoot_(ByVal a As Double, ByVal n As Double) As Double
        Dim m As Double
        '7.10.2003 thanks to Rodigro Farinha
        'algebric extension of root for a<0
        m = Int(n)  'only integer here
        If m = 0 Then
            MiRoot_ = "" 'raise an error
        ElseIf Mod_(m, 2) = 0 Then 'm is even => root in a<0 doesn´t exist
            If a < 0 Then
                MiRoot_ = "" 'raise an error
            Else
                MiRoot_ = a ^ (1 / m)
            End If
        Else  'm is odd => root in a<0 exists
            MiRoot_ = Sign(a) * Abs(a) ^ (1 / m)
        End If
    End Function

    'compute the unique nonnegative remainder on division
    'of the integer x by the integer n
    '1-3-07
    Private Function Mod_(ByVal a As Double, ByVal b As Double) As Double
        'fix the Excel VBA Bug
        Dim c, d, e
        c = Int(Abs(a))
        d = Int(Abs(b))
        e = Round(c - d * Int(c / d), 0)
        If a < 0 Then e = d - e
        Mod_ = e
    End Function

    Private Function Dec_(ByVal a As Double) As Double
        Dim z As Double, n As Integer
        z = a - Fix(a)
        n = Int(Log(Abs(a)) / Log(10)) + 1 'integer digits
        z = Round(z, 15 - n)
        Dec_ = z
    End Function

    Private Function CheckInt(ByVal a As Double) As Double
        'check if a value is integer
        'raises an error if variable a is not integer
        Dim temp As Double, d As Double
        Const Tiny = 5 * 10 ^ -14
        d = Round(a, 0)
        temp = Abs(d - a)
        If temp > Tiny Then CheckInt = "" 'raises an error
        CheckInt = d
    End Function

    'use only for debug
    Sub ET_Dump(ByRef ETable(,) As Object)
        ReDim ETable(ETtop, 30)
        Dim i As Integer, j As Integer

        j = j + 1 : ETable(0, j) = "Fun"
        j = j + 1 : ETable(0, j) = "ArgTop"
        j = j + 1 : ETable(0, j) = "A1 Idx"
        j = j + 1 : ETable(0, j) = "Arg1 Name"
        j = j + 1 : ETable(0, j) = "Arg1 Value"
        j = j + 1 : ETable(0, j) = "A2 Idx"
        j = j + 1 : ETable(0, j) = "Arg2 Name"
        j = j + 1 : ETable(0, j) = "Arg2 Value"
        j = j + 1 : ETable(0, j) = "ArgOf"
        j = j + 1 : ETable(0, j) = "ArgIdx"
        j = j + 1 : ETable(0, j) = "Value"
        j = j + 1 : ETable(0, j) = "PriLvl"
        j = j + 1 : ETable(0, j) = "PosInExpr"
        j = j + 1 : ETable(0, j) = "PriIdx"
        j = j + 1 : ETable(0, j) = "Cond"
        ReDim Preserve ETable(ETtop, j)
        For i = 1 To UBound(ET)
            j = 0
            With ET(i)
                j = j + 1 : ETable(i, j) = .Fun
                j = j + 1 : ETable(i, j) = .ArgTop
                j = j + 1 : ETable(i, j) = .Arg(1).Idx
                j = j + 1 : ETable(i, j) = .Arg(1).Nome
                j = j + 1 : ETable(i, j) = .Arg(1).Value
                j = j + 1 : ETable(i, j) = .Arg(2).Idx
                j = j + 1 : ETable(i, j) = .Arg(2).Nome
                j = j + 1 : ETable(i, j) = .Arg(2).Value
                j = j + 1 : ETable(i, j) = .ArgOf
                j = j + 1 : ETable(i, j) = .ArgIdx
                j = j + 1 : ETable(i, j) = .Value
                j = j + 1 : ETable(i, j) = .PriLvl
                j = j + 1 : ETable(i, j) = .PosInExpr
                j = j + 1 : ETable(i, j) = .PriIdx
                j = j + 1 : ETable(i, j) = .Cond
            End With
        Next
    End Sub


    Private Function DNormal(ByVal x As Double, ByVal avg As Double, ByVal dev As Double) As Double
        'normal distribution
        Dim p As Double
        p = (x - avg) ^ 2 / (2 * dev ^ 2)
        DNormal = Exp(-p) / Sqrt(2 * PI_) / dev
    End Function

    Private Function CNormal(ByVal x As Double, ByVal avg As Double, ByVal dev As Double) As Double
        'cumulative normal distribution
        Dim p As Double
        p = (x - avg) / (Sqrt(2) * dev)
        CNormal = (1 + erf_(p)) / 2
    End Function

    Private Function DBinomial(ByVal k As Double, ByVal n As Double, ByVal p As Double) As Double
        'k = class, N = population, p = probability
        k = CheckInt(k)
        n = CheckInt(n)
        DBinomial = Comb(n, n - k) * p ^ k * (1 - p) ^ (n - k)
    End Function
    '
    Private Function CBinomial(ByVal k As Double, ByVal n As Double, ByVal p As Double) As Double
        'k = class, N = population, p = probability
        Dim i As Integer, y As Double
        k = CheckInt(k)
        n = CheckInt(n)
        For i = 1 To k
            y = y + DBinomial(i, n, p)
        Next i
        CBinomial = y
    End Function

    Private Function DPoisson(ByVal k As Double, ByVal z As Double) As Double
        'Poisson density
        ' k = events, z = average
        Dim y As Double
        k = CheckInt(k)
        y = -z + k * Log(z) - gammaln_(k + 1)
        DPoisson = Exp(y)
    End Function

    Private Function CPoisson(ByVal k As Double, ByVal z As Double) As Double
        'Poisson cumulative distribution
        ' k = events, z = average
        Dim y As Double, i As Integer
        k = CheckInt(k)
        For i = 1 To k
            y = y + DPoisson(i, z)
        Next
        CPoisson = y
    End Function

    Private Function expn_integr(ByVal x As Double, ByVal n As Double) As Double
        'Evaluates the exponential integral En(x).
        Dim y As Double
        Call Hexpn_integr(x, n, y)
        expn_integr = y
    End Function

    Private Function BetaInc(ByVal x As Double, ByVal a As Double, ByVal b As Double) As Double
        'incomplete gamma function
        Dim BIX As Double
        Call INCOB(a, b, x, BIX)
        BetaInc = BIX
    End Function

    Private Function GammaInc(ByVal a As Double, ByVal x As Double) As Double
        'incomplete gamma function
        Dim GIN As Double, GIM As Double, GIP As Double, MSG As String
        Call INCOG(a, x, GIN, GIM, GIP, MSG)
        If MSG <> "" Then GammaInc = "" 'raise an error
        GammaInc = GIM  '23.3.06
    End Function

    '22-02.2007
    Private Function Hypergeom(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal x As Double) As Double
        Dim hf As Double, ErrorMsg As String
        If x > 1 Then GoTo Error_Handler
        Call HYGFX(a, b, c, x, hf, ErrorMsg)
        If ErrorMsg <> "" Then GoTo Error_Handler
        Hypergeom = hf
        Exit Function
Error_Handler:
        Hypergeom = ""  'raise an error
    End Function

    Private Function BesselJ(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'Bessel function 1st kind, order n, Jn(x)
        Dim BJ0#, DJ0#, BJ1#, DJ1#, BY0#, DY0#, BY1#, DY1#, NM#, BJ#(), DJ#(), BY#(), DY#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call JY01A(x, BJ0, DJ0, BJ1, DJ1, BY0, DY0, BY1, DY1)
            If n = 0 Then BesselJ = BJ0 Else BesselJ = BJ1
        Else
            Call JYNA(n, x, NM, BJ, DJ, BY, DY)
            BesselJ = BJ(n)
        End If
    End Function

    Private Function BesselY(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'Bessel function 2nd kind, order n, Yn(x)
        Dim BJ0#, DJ0#, BJ1#, DJ1#, BY0#, DY0#, BY1#, DY1#, NM#, BJ#(), DJ#(), BY#(), DY#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call JY01A(x, BJ0, DJ0, BJ1, DJ1, BY0, DY0, BY1, DY1)
            If n = 0 Then BesselY = BY0 Else BesselY = BY1
        Else
            Call JYNA(n, x, NM, BJ, DJ, BY, DY)
            BesselY = BY(n)
        End If
    End Function

    Private Function BesseldJ(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'First Derivative of Bessel functions first kind, order n, J'n(x)
        Dim BJ0#, DJ0#, BJ1#, DJ1#, BY0#, DY0#, BY1#, DY1#, NM#, BJ#(), DJ#(), BY#(), DY#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call JY01A(x, BJ0, DJ0, BJ1, DJ1, BY0, DY0, BY1, DY1)
            If n = 0 Then BesseldJ = DJ0 Else BesseldJ = DJ1
        Else
            Call JYNA(n, x, NM, BJ, DJ, BY, DY)
            BesseldJ = DJ(n)
        End If
    End Function

    Private Function BesseldY(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'First Derivative of Bessel functions second kind, order n, Y'n(x)
        Dim BJ0#, DJ0#, BJ1#, DJ1#, BY0#, DY0#, BY1#, DY1#, NM#, BJ#(), DJ#(), BY#(), DY#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call JY01A(x, BJ0, DJ0, BJ1, DJ1, BY0, DY0, BY1, DY1)
            If n = 0 Then BesseldY = DY0 Else BesseldY = DY1
        Else
            Call JYNA(n, x, NM, BJ, DJ, BY, DY)
            BesseldY = DY(n)
        End If
    End Function

    Private Function BesselI(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'modified Bessel function 1st kind, order n, In(x)
        Dim BI0#, DI0#, BI1#, DI1#, BK0#, DK0#, BK1#, DK1#, NM#, BI#(), DI#(), BK#(), DK#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call IK01A(x, BI0, DI0, BI1, DI1, BK0, DK0, BK1, DK1)
            If n = 0 Then BesselI = BI0 Else BesselI = BI1
        Else
            Call IKNA(n, x, NM, BI, DI, BK, DK)
            BesselI = BI(n)
        End If
    End Function

    Private Function BesseldI(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'derivative modified Bessel function 1° kind, order n, In(x)
        Dim BI0#, DI0#, BI1#, DI1#, BK0#, DK0#, BK1#, DK1#, NM#, BI#(), DI#(), BK#(), DK#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call IK01A(x, BI0, DI0, BI1, DI1, BK0, DK0, BK1, DK1)
            If n = 0 Then BesseldI = DI0 Else BesseldI = DI1
        Else
            Call IKNA(n, x, NM, BI, DI, BK, DK)
            BesseldI = DI(n)
        End If
    End Function

    Private Function BesselK(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'modified Bessel function 2nd kind, order n, In(x)
        Dim BI0#, DI0#, BI1#, DI1#, BK0#, DK0#, BK1#, DK1#, NM#, BI#(), DI#(), BK#(), DK#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call IK01A(x, BI0, DI0, BI1, DI1, BK0, DK0, BK1, DK1)
            If n = 0 Then BesselK = BK0 Else BesselK = BK1
        Else
            Call IKNA(n, x, NM, BI, DI, BK, DK)
            BesselK = BK(n)
        End If
    End Function

    Private Function BesseldK(ByVal x As Double, Optional ByVal n As Double = 1) As Double
        'derivative of modified Bessel function 2° kind, order n, In(x)
        Dim BI0#, DI0#, BI1#, DI1#, BK0#, DK0#, BK1#, DK1#, NM#, BI#(), DI#(), BK#(), DK#()
        If IsNothing(n) Then n = 0
        If n <= 1 Then
            Call IK01A(x, BI0, DI0, BI1, DI1, BK0, DK0, BK1, DK1)
            If n = 0 Then BesseldK = DK0 Else BesseldK = DK1
        Else
            Call IKNA(n, x, NM, BI, DI, BK, DK)
            BesseldK = DK(n)
        End If
    End Function

    Private Function CosIntegral(ByVal x As Double) As Double
        'returns cos integral ci(x)
        Dim CI As Double, SI As Double
        Call CISIA(x, CI, SI)
        CosIntegral = CI
    End Function

    Private Function SinIntegral(ByVal x As Double) As Double
        'returns sin integral ci(x)
        Dim CI As Double, SI As Double
        Call CISIA(Abs(x), CI, SI)
        SinIntegral = Sign(x) * SI
    End Function

    Private Function Fresnel_cos(ByVal x As Double) As Double
        'returns Fresnel's cos integral
        Dim Fr_c As Double, Fr_s As Double
        Call FCS(x, Fr_c, Fr_s)
        Fresnel_cos = Fr_c
    End Function

    Private Function Fresnel_sin(ByVal x As Double) As Double
        'returns Fresnel's sin integral
        Dim Fr_c As Double, Fr_s As Double
        Call FCS(x, Fr_c, Fr_s)
        Fresnel_sin = Fr_s
    End Function

    Private Function Poly_Legendre(ByVal x As Double, ByVal n As Double) As Double
        Dim y As Double
        n = CheckInt(n)
        Call PLegendre(x, n, y)
        Poly_Legendre = y
    End Function

    Private Function Poly_Hermite(ByVal x As Double, ByVal n As Double) As Double
        Dim y As Double
        n = CheckInt(n)
        Call PHermite(x, n, y)
        Poly_Hermite = y
    End Function

    Private Function Poly_Laguerre(ByVal x As Double, ByVal n As Double) As Double
        Dim y As Double
        n = CheckInt(n)
        Call PLaguerre(x, n, y)
        Poly_Laguerre = y
    End Function

    Private Function Poly_Chebycev(ByVal x As Double, ByVal n As Double) As Double
        Dim y As Double
        n = CheckInt(n)
        Call PChebycev(x, n, y)
        Poly_Chebycev = y
    End Function

    Private Function Airy_A(ByVal x As Double) As Double
        Dim y As Double, AI As Double, BI As Double, AD As Double, BD As Double
        Call AIRYB(x, AI, BI, AD, BD)
        Airy_A = AI
    End Function

    Private Function Airy_B(ByVal x As Double) As Double
        Dim y As Double, AI As Double, BI As Double, AD As Double, BD As Double
        Call AIRYB(x, AI, BI, AD, BD)
        Airy_B = BI
    End Function

    Private Function IElliptic_Int1(ByVal x As Double, ByVal phi As Double) As Double
        ' incomplete elliptic integral 1st kind
        Dim e1 As Double, e2 As Double, phideg As Double
        phideg = 180 * phi / PI_
        Call ELIT(x, phideg, e1, e2)
        IElliptic_Int1 = e1
    End Function

    Private Function IElliptic_Int2(ByVal x As Double, ByVal phi As Double) As Double
        ' incomplete elliptic integral 2nd kind
        Dim e1 As Double, e2 As Double, phideg As Double
        phideg = 180 * phi / PI_
        Call ELIT(x, phideg, e1, e2)
        IElliptic_Int2 = e2
    End Function

    'clipping function
    Private Function Clip(ByVal t, ByVal Floor, ByVal Ceeling) As Double
        Dim y As Double
        If Floor > Ceeling Then Clip = "" 'raise an error
        If t < Floor Then
            y = Floor
        ElseIf t > Ceeling Then
            y = Ceeling
        Else
            y = t
        End If
        Clip = y
    End Function

    'step function or Haveside's function
    Private Function Step_(ByVal x, ByVal a) As Double
        If x >= a Then
            Step_ = 1
        Else
            Step_ = 0
        End If
    End Function


    'sum of n-numbers
    Private Function sum_(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        For i = 1 To n
            ris = ris + x(i)
        Next i
        sum_ = ris
    End Function

    'arithemtic mean of n-numbers
    Private Function mean_(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        For i = 1 To n
            ris = ris + x(i)
        Next i
        mean_ = ris / n
    End Function

    'geometric mean of n-numbers
    Private Function meang_(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        ris = 1
        For i = 1 To n
            ris = ris * (x(i) ^ (1 / n))
        Next i
        meang_ = ris
    End Function

    'quadratic mean of n-numbers
    Private Function meanq_(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double
        n = UBound(x)
        ris = 0
        For i = 1 To n
            ris = ris + x(i) ^ 2
        Next i
        meanq_ = Sqrt(ris / n)
    End Function

    'variance (pop) of n-numbers
    Private Function varp_(ByVal x() As Double) As Double
        Dim n As Integer, i As Integer, ris As Double, mu As Double
        n = UBound(x)
        mu = mean_(x)
        ris = 0
        For i = 1 To n
            ris = ris + (x(i) - mu) ^ 2
        Next i
        varp_ = ris / n
    End Function

    'variance of n-numbers
    Private Function var_(ByVal x() As Double) As Double
        Dim n As Integer
        n = UBound(x)
        var_ = varp_(x) * n / (n - 1)
    End Function

    'standard deviation of n-numbers
    Private Function stdev_(ByVal x() As Double) As Double
        stdev_ = Sqrt(var_(x))
    End Function

    'standard deviation (pop) of n-numbers
    Private Function stdevp_(ByVal x() As Double) As Double
        stdevp_ = Sqrt(varp_(x))
    End Function

    Private Sub ErrorTab_Init()
        ReDim ErrorTbl(50)
        ErrorTbl(1) = "too many variables"
        ErrorTbl(2) = "Variable not found"
        ErrorTbl(3) = "" 'spare
        ErrorTbl(4) = "abs symbols |.| mismatch"
        ErrorTbl(5) = "Syntax error at pos: $"
        ErrorTbl(6) = "Function < $ > unknown at pos: $"
        ErrorTbl(7) = "Too many closing brackets at pos: $"
        ErrorTbl(8) = "missing argument"
        ErrorTbl(9) = "Too many arguments at pos: $"
        ErrorTbl(10) = "" 'spare
        ErrorTbl(11) = "Not enough closing brackets"
        ErrorTbl(12) = "Syntax error: $"
        ErrorTbl(13) = "Function < $ > missing?"
        ErrorTbl(14) = "Evaluation error < $($) > at pos: $"
        ErrorTbl(15) = "Evaluation error < $($" & ArgSep & " $) > at pos: $"
        ErrorTbl(16) = "Evaluation error < $ $ $ > at pos: $"
        ErrorTbl(17) = "Evaluation error < $($) > at pos: $"
        ErrorTbl(18) = "Variable < $ > not assigned"
        ErrorTbl(19) = "Constant unknown: $"
        ErrorTbl(20) = "Too many operations"
        ErrorTbl(21) = "Wrong DMS format"
        ErrorTbl(22) = "No DMS format"
    End Sub

    'get a message from the error-table and substitute the parameters
    Private Function getMsg(ByVal Id, Optional ByVal p1 = Nothing, Optional ByVal p2 = Nothing, Optional ByVal p3 = Nothing, Optional ByVal p4 = Nothing)
        Dim i As Integer, s As String, p
        ErrId = Id          'set the global id
        s = ErrorTbl(ErrId) 'get the message template
        If Not IsNothing(p1) Then ParamSubstitute(p1, s)
        If Not IsNothing(p2) Then ParamSubstitute(p2, s)
        If Not IsNothing(p3) Then ParamSubstitute(p3, s)
        If Not IsNothing(p4) Then ParamSubstitute(p4, s)
        getMsg = s
    End Function

    Private Sub ParamSubstitute(ByVal p, ByVal s)
        Dim i As Integer
        i = InStr(1, s, "$")
        If i > 0 Then
            s = Left(s, i - 1) & p & Right(s, Len(s) - i)
        End If
    End Sub

    ' > Mirko 20061018
    Private Function GetNumberOfArguments(ByVal strExpr) As Integer
        'Count number of commas between parenthesis. Ignore commas in subparenthesis
        Dim i As Integer
        Dim numCommas As Integer
        Dim numOpenPar As Integer
        Do
            i = i + 1
            If Mid(strExpr, i, 1) = "(" Then
                numOpenPar = numOpenPar + 1
            ElseIf Mid(strExpr, i, 1) = ")" Then
                numOpenPar = numOpenPar - 1
            ElseIf Mid(strExpr, i, 1) = ArgSep And numOpenPar = 1 Then
                numCommas = numCommas + 1
            End If
        Loop While numOpenPar > 0 And i < Len(strExpr)
        If i = Len(strExpr) And numOpenPar > 0 Then numCommas = 0
        GetNumberOfArguments = numCommas + 1
    End Function
    ' < Mirko 20061018

#Region "special functions"
    '
    '*******************************************************************************
    ' CREDITS                                                                       '
    ' Many routines of this VB module was derived from the                          '
    ' LIBRARY FOR COMPUTATION of SPECIAL FUNCTIONS written in FORTRAN-77            '
    ' by Shanjie Zhang and Jianming Jin.                                            '
    ' All these programs and subroutines are copyrighted.                           '
    ' However, authors give kindly permission to incorporate any of these           '
    ' routines into other programs providing that the copyright is acknowledged.    '
    ' We have modified only minimal parts in order to adapt them to VB and VBA.     '
    '*******************************************************************************

    '-------------------------------------------------------------------------------
    ' error distribution function
    '-------------------------------------------------------------------------------
    Sub Herf(ByVal x As Double, ByRef y As Double)
        Const MaxLoop As Integer = 400
        Const Tiny As Double = 0.000000000000001
        Dim t As Double, p As Double, s As Double, i As Integer
        Dim A0 As Double, B0 As Double, A1 As Double, B1 As Double, A2 As Double, b2 As Double
        Dim F1 As Double, F2 As Double, G As Double, d As Double
        If x <= 2 Then
            t = 2 * x * x
            p = 1
            s = 1
            For i = 3 To MaxLoop Step 2
                p = p * t / i
                s = s + p
                If p < Tiny Then Exit For
            Next
            y = 2 * s * x * Exp(-x * x) / Sqrt(PI_)
        Else
            A0 = 1 : B0 = 0
            A1 = 0 : B1 = 1
            F1 = 0
            For i = 1 To MaxLoop
                G = 2 - (i Mod 2)
                A2 = G * x * A1 + i * A0
                b2 = G * x * B1 + i * B0
                F2 = A2 / b2
                d = Abs(F2 - F1)
                If d < Tiny Then Exit For
                A0 = A1 : B0 = B1
                A1 = A2 : B1 = b2
                F1 = F2
            Next
            y = 1 - 2 * Exp(-x * x) / (2 * x + F2) / Sqrt(PI_)
        End If
    End Sub

    '-------------------------------------------------------------------------------
    ' gamma function
    '-------------------------------------------------------------------------------
    Sub HGamma(ByVal x As Double, ByRef y As Double)
        'compute y = gamma(x)
        Dim mantissa As Double, Expo As Double
        gamma_split(x, mantissa, Expo)
        y = mantissa * 10 ^ Expo
    End Sub

    ' gamma  - Lanczos approximation algorithm for gamma function
    Sub gamma_split(ByVal x As Double, ByRef mantissa As Double, ByRef Expo As Double)
        Dim z As Double, Cf(14) As Double, w As Double, i As Integer, s As Double, p As Double
        Const DOUBLEPI As Double = 6.28318530717959
        Const G_ As Double = 4.7421875  '607/128
        z = x - 1

        Cf(0) = 0.999999999999997
        Cf(1) = 57.1562356658629
        Cf(2) = -59.5979603554755
        Cf(3) = 14.1360979747417
        Cf(4) = -0.49191381609762
        Cf(5) = 0.0000339946499848119
        Cf(6) = 0.0000465236289270486
        Cf(7) = -0.0000983744753048796
        Cf(8) = 0.000158088703224912
        Cf(9) = -0.000210264441724105
        Cf(10) = 0.000217439618115213
        Cf(11) = -0.000164318106536764
        Cf(12) = 0.0000844182239838528
        Cf(13) = -0.0000261908384015814
        Cf(14) = 0.00000368991826595316

        w = Exp(G_) / Sqrt(DOUBLEPI)
        s = Cf(0)
        For i = 1 To 14
            s = s + Cf(i) / (z + i)
        Next
        s = s / w
        p = Log((z + G_ + 0.5) / Exp(1)) * (z + 0.5) / Log(10)
        'split in mantissa and exponent to avoid overflow
        Expo = Int(p)
        p = p - Int(p)
        mantissa = 10 ^ p * s
        'rescaling
        p = Int(Log(mantissa) / Log(10))
        mantissa = mantissa * 10 ^ -p
        Expo = Expo + p
    End Sub

    '-------------------------------------------------------------------------------
    ' logarithm gamma function
    '-------------------------------------------------------------------------------
    Private Function gammaln_(ByVal x)
        Dim mantissa As Double, Expo As Double
        gamma_split(x, mantissa, Expo)
        gammaln_ = Log(mantissa) + Expo * Log(10)
    End Function

    '-------------------------------------------------------------------------------
    ' beta function
    '---------------------------------------------------------------------------------
    Sub HBeta(ByVal z, ByVal w, ByVal y)
        y = Exp(gammaln_(z) + gammaln_(w) - gammaln_(z + w))
    End Sub

    '-------------------------------------------------------------------------------
    ' digamma function
    '-------------------------------------------------------------------------------
    Sub HDigamma(ByVal x As Double, ByRef y As Double)
        Dim B1(11) As Double, b2(11) As Double
        Dim z As Double, s As Double, k As Integer, Tmp As Double
        Const LIM_LOW As Integer = 8
        'Bernoulli's numbers
        B1(0) = 1 : b2(0) = 1
        B1(1) = 1 : b2(1) = 6
        B1(2) = -1 : b2(2) = 30
        B1(3) = 1 : b2(3) = 42
        B1(4) = -1 : b2(4) = 30
        B1(5) = 5 : b2(5) = 66
        B1(6) = -691 : b2(6) = 2730
        B1(7) = 7 : b2(7) = 6
        B1(8) = -3617 : b2(8) = 360
        B1(9) = 43867 : b2(9) = 798
        B1(10) = -174611 : b2(10) = 330
        B1(11) = 854513 : b2(11) = 138
        If x <= LIM_LOW Then
            z = x - 1 + LIM_LOW
        Else
            z = x - 1
        End If
        s = 0
        For k = 1 To 11
            Tmp = B1(k) / b2(k) / k / z ^ (2 * k)
            s = s + Tmp
        Next
        y = Log(z) + 0.5 * (1 / z - s)

        If x <= LIM_LOW Then
            s = 0
            For k = 0 To LIM_LOW - 1
                s = s + 1 / (x + k)
            Next
            y = y - s
        End If
    End Sub

    '-------------------------------------------------------------------------------
    ' Riemman's zeta function
    '-------------------------------------------------------------------------------
    Sub HZeta(ByVal x As Double, ByRef y As Double)
        Dim Cnk As Double, k As Integer, n As Integer, s As Double, s1 As Double, coeff As Double
        Const N_MAX As Integer = 1000
        Const Tiny As Double = 0.0000000000000001
        n = 0 : s = 0
        Do
            s1 = 0 : Cnk = 1
            For k = 0 To n
                If k > 0 Then Cnk = Cnk * (n - k + 1) / k
                s1 = s1 + (-1) ^ k * Cnk / (k + 1) ^ x
            Next k
            coeff = s1 / 2 ^ (1 + n)
            s = s + coeff
            n = n + 1
        Loop Until Abs(coeff) < Tiny Or n > N_MAX
        y = s / (1 - 2 ^ (1 - x))
    End Sub

    '-------------------------------------------------------------------------------
    ' exponential integral Ei(x) for x >0.
    '-------------------------------------------------------------------------------
    Sub Hexp_integr(ByVal x As Double, ByRef y As Double)
        Dim k As Integer, fact As Double, prev As Double, sum As Double, Term As Double
        Const EPS As Double = 0.000000000000001
        Const EULER As Double = 0.577215664901532
        Const MAXIT As Integer = 100, FPMIN As Double = 1.0E-30
        If (x <= 0) Then Exit Sub '
        If (x < FPMIN) Then          'Special case: avoid failure of convergence test be-
            y = Log(x) + EULER            'cause of under ow.
        ElseIf (x <= -Log(EPS)) Then 'Use power series.
            sum = 0
            fact = 1
            For k = 1 To MAXIT
                fact = fact * x / k
                Term = fact / k
                sum = sum + Term
                If (Term < EPS * sum) Then Exit For
            Next
            y = sum + Log(x) + EULER
        Else 'Use asymptotic series.
            sum = 0 'Start with second term.
            Term = 1
            For k = 1 To MAXIT
                prev = Term
                Term = Term * k / x
                If (Term < EPS) Then Exit For 'Since al sum is greater than one, term itself ap-
                If (Term < prev) Then
                    sum = sum + Term 'Still converging: add new term.
                Else
                    sum = sum - prev 'Diverging: subtract previous term and exit.
                    Exit For
                End If
            Next
            y = Exp(x) * (1 + sum) / x
        End If
    End Sub


    Sub Hexpn_integr(ByVal x As Double, ByVal n As Double, ByRef y As Double)
        'Evaluates the exponential integral En(x).
        'Parameters: MAXIT is the maximum allowed number of iterations; EPS is the desired rel-
        'ative error, not smaller than the machine precision; FPMIN is a number near the smallest
        'representable foating-point number; EULER is Euler's constant .
        Const MAXIT As Integer = 100
        Const EPS As Double = 0.000000000000001
        Const FPMIN As Double = 1.0E-30
        Const EULER As Double = 0.577215664901532
        Dim nm1 As Integer, a As Double, b As Double, c As Double, d As Double, h As Double, i As Integer, del As Double, fact As Double, Psi As Double, ii As Integer
        nm1 = n - 1
        If (n < 0 Or x < 0 Or (x = 0 And (n = 0 Or n = 1))) Then
            Exit Sub
        ElseIf (n = 0) Then 'Special case.
            y = Exp(-x) / x
        ElseIf (x = 0) Then 'Another special case.
            y = 1 / nm1
        ElseIf (x > 1) Then 'Lentz's algorithm .
            b = x + n
            c = 1 / FPMIN
            d = 1 / b
            h = d
            For i = 1 To MAXIT
                a = -i * (nm1 + i)
                b = b + 2
                d = 1 / (a * d + b)  'Denominators cannot be zero.
                c = b + a / c
                del = c * d
                h = h * del
                If (Abs(del - 1) < EPS) Then
                    y = h * Exp(-x)
                    Exit Sub
                End If
            Next
            y = "?"
            Exit Sub      'continued fraction failed '
        Else 'Evaluate series.
            If (nm1 <> 0) Then 'Set rst term.
                y = 1 / nm1
            Else
                y = -Log(x) - EULER
            End If
            fact = 1
            For i = 1 To MAXIT
                fact = -fact * x / i
                If (i <> nm1) Then
                    del = -fact / (i - nm1)
                Else
                    Psi = -EULER '.
                    For ii = 1 To nm1
                        Psi = Psi + 1 / ii
                    Next
                    del = fact * (-Log(x) + Psi)
                End If
                y = y + del
                If (Abs(del) < Abs(y) * EPS) Then Exit Sub
            Next
            y = "?"
            Exit Sub      'series failed in'
        End If

    End Sub

    Sub JY01A(ByVal x As Double, ByRef BJ0 As Double, ByRef DJ0 As Double, ByRef BJ1 As Double, ByRef DJ1 As Double, ByRef BY0 As Double, ByRef DY0 As Double, ByRef BY1 As Double, ByRef DY1 As Double)
        '=======================================================
        ' Purpose: Compute Bessel functions J0(x), J1(x), Y0(x),
        '         Y1(x), and their derivatives
        ' Input :  x   --- Argument of Jn(x) & Yn(x) ( x ò 0 )
        ' Output:  BJ0 --- J0(x)
        '          DJ0 --- J0'(x)
        '          BJ1 --- J1(x)
        '          DJ1 --- J1'(x)
        '          BY0 --- Y0(x)
        '          DY0 --- Y0'(x)
        '          BY1 --- Y1(x)
        '          DY1 --- Y1'(x)
        '=======================================================
        Dim rp2 As Double, X2 As Double, r As Double, k As Integer, EC As Double, CS0 As Double, CS1 As Double, W0 As Double, W1 As Double, R0 As Double, R1 As Double
        Dim K0 As Double, T1 As Double, p0 As Double, p1 As Double, q0 As Double, q1 As Double, i As Integer, CU As Double, T2 As Double
        rp2 = 0.63661977236758
        X2 = x * x

        Dim A0() As Double = {-0.0703125, 0.112152099609375, _
                 -0.572501420974731, 6.07404200127348, _
                 -110.017140269247, 3038.09051092238, _
                 -118838.426256783, 6252951.4934348, _
                 -425939216.504767, 36468400807.0656, _
                 -3833534661393.94, 485401468685290.0#}
        Dim B0() As Double = {0.0732421875, -0.227108001708984, _
                   1.72772750258446, -24.3805296995561, _
                   551.335896122021, -18257.7554742932, _
                   832859.304016289, -50069589.5319889, _
                   3836255180.23043, -364901081884.983, _
                   42189715702841.0#, -5.82724463156691E+15}
        Dim A1() As Double = {0.1171875, -0.144195556640625, _
                   0.676592588424683, -6.88391426810995, _
                   121.597891876536, -3302.27229448085, _
                   127641.272646175, -6656367.71881769, _
                   450278600.305039, -38338575207.4279, _
                   4011838599133.2, -506056850331473.0#}
        Dim B1() As Double = {-0.1025390625, 0.277576446533203, _
                   -1.9935317337513, 27.2488273112685, _
                   -603.84407670507, 19718.3759122366, _
                   -890297.876707068, 53104110.1096852, _
                   -4043620325.10775, 382701134659.86, _
                   -44064814178522.8, 6.0650913512227E+15}


        If (x = 0) Then
            BJ0 = 1
            BJ1 = 0
            DJ0 = 0
            DJ1 = 0.5
            BY0 = -1.0E+300
            BY1 = -1.0E+300
            DY0 = 1.0E+300
            DY1 = 1.0E+300
            Return
        End If
        If (x <= 12) Then
            BJ0 = 1
            r = 1
            For k = 1 To 30
                r = -0.25 * r * X2 / (k * k)
                BJ0 = BJ0 + r
                If (Abs(r) < Abs(BJ0) * 0.000000000000001) Then Exit For
            Next
            BJ1 = 1
            r = 1
            For k = 1 To 30
                r = -0.25 * r * X2 / (k * (k + 1))
                BJ1 = BJ1 + r
                If (Abs(r) < Abs(BJ1) * 0.000000000000001) Then Exit For
            Next
            BJ1 = 0.5 * x * BJ1
            EC = Log(x / 2) + 0.577215664901533
            CS0 = 0
            W0 = 0
            R0 = 1
            For k = 1 To 30
                W0 = W0 + 1 / k
                R0 = -0.25 * R0 / (k * k) * X2
                r = R0 * W0
                CS0 = CS0 + r
                If (Abs(r) < Abs(CS0) * 0.000000000000001) Then Exit For
            Next
            BY0 = rp2 * (EC * BJ0 - CS0)
            CS1 = 1
            W1 = 0
            R1 = 1
            For k = 1 To 30
                W1 = W1 + 1 / k
                R1 = -0.25 * R1 / (k * (k + 1)) * X2
                r = R1 * (2 * W1 + 1 / (k + 1))
                CS1 = CS1 + r
                If (Abs(r) < Abs(CS1) * 0.000000000000001) Then Exit For
            Next
            BY1 = rp2 * (EC * BJ1 - 1 / x - 0.25 * x * CS1)
        Else

            K0 = 12
            If (x >= 35) Then K0 = 10
            If (x >= 50) Then K0 = 8
            T1 = x - 0.25 * PI_
            p0 = 1
            q0 = -0.125 / x
            For k = 1 To K0
                i = k - 1
                p0 = p0 + A0(i) * x ^ (-2 * k)
                q0 = q0 + B0(i) * x ^ (-2 * k - 1)
            Next
            CU = Sqrt(rp2 / x)
            BJ0 = CU * (p0 * Cos(T1) - q0 * Sin(T1))
            BY0 = CU * (p0 * Sin(T1) + q0 * Cos(T1))
            T2 = x - 0.75 * PI_
            p1 = 1
            q1 = 0.375 / x
            For k = 1 To K0
                i = k - 1
                p1 = p1 + A1(i) * x ^ (-2 * k)
                q1 = q1 + B1(i) * x ^ (-2 * k - 1)
            Next
            CU = Sqrt(rp2 / x)
            BJ1 = CU * (p1 * Cos(T2) - q1 * Sin(T2))
            BY1 = CU * (p1 * Sin(T2) + q1 * Cos(T2))
        End If
        DJ0 = -BJ1
        DJ1 = BJ0 - BJ1 / x
        DY0 = -BY1
        DY1 = BY0 - BY1 / x
    End Sub


    Sub JYNA(ByVal n As Double, ByVal x As Double, ByRef NM As Double, ByRef BJ() As Double, ByRef DJ() As Double, ByRef BY() As Double, ByRef DY() As Double)
        '  ==========================================================
        '       Purpose: Compute Bessel functions Jn(x) & Yn(x) and
        '                their derivatives
        '       Input :  x --- Argument of Jn(x) & Yn(x)  ( x > 0 )
        '                n --- Order of Jn(x) & Yn(x)
        '       Output:  BJ(n) --- Jn(x)
        '                DJ(n) --- Jn'(x)
        '                BY(n) --- Yn(x)
        '                DY(n) --- Yn'(x)
        '                NM --- Highest order computed
        '       Routines called:
        '            (1) JY01A to calculate J0(x), J1(x), Y0(x) & Y1(x)
        '            (2) MSTA1 and MSTA2 to calculate the starting
        '                point for backward recurrence
        '  =========================================================
        Dim k As Double, BJ0 As Double, DJ0 As Double, BJ1 As Double, DJ1 As Double, BY0 As Double, DY0 As Double, BY1 As Double, DY1 As Double, BJK As Double, m As Double, F2 As Double, F1 As Double, F As Double, F0 As Double, CS As Double
        ReDim BJ(n), BY(n), DJ(n), DY(n)
        NM = n
        If (x < 1.0E-100) Then
            For k = 0 To n
                BJ(k) = 0
                DJ(k) = 0
                BY(k) = -1.0E+300
                DY(k) = 1.0E+300
            Next
            BJ(0) = 1
            DJ(1) = 0.5
            Exit Sub
        End If
        Call JY01A(x, BJ0, DJ0, BJ1, DJ1, BY0, DY0, BY1, DY1)
        BJ(0) = BJ0
        BJ(1) = BJ1
        BY(0) = BY0
        BY(1) = BY1
        DJ(0) = DJ0
        DJ(1) = DJ1
        DY(0) = DY0
        DY(1) = DY1
        If (n <= 1) Then Exit Sub
        If (n < Int(0.9 * x)) Then
            For k = 2 To n
                BJK = 2 * (k - 1) / x * BJ1 - BJ0
                BJ(k) = BJK
                BJ0 = BJ1
                BJ1 = BJK
            Next
        Else
            m = MSTA1(x, 200)
            If (m < n) Then
                NM = m
            Else
                m = MSTA2(x, n, 15)
            End If
            F2 = 0
            F1 = 1.0E-100
            For k = m To 0 Step -1
                F = 2 * (k + 1) / x * F1 - F2
                If (k <= NM) Then BJ(k) = F
                F2 = F1
                F1 = F
            Next
            If (Abs(BJ0) > Abs(BJ1)) Then
                CS = BJ0 / F
            Else
                CS = BJ1 / F2
            End If
            For k = 0 To NM
                BJ(k) = CS * BJ(k)
            Next
        End If

        For k = 2 To NM
            DJ(k) = BJ(k - 1) - k / x * BJ(k)
        Next
        F0 = BY(0)
        F1 = BY(1)
        For k = 2 To NM
            F = 2 * (k - 1) / x * F1 - F0
            BY(k) = F
            F0 = F1
            F1 = F
        Next
        For k = 2 To NM
            DY(k) = BY(k - 1) - k * BY(k) / x
        Next
    End Sub


    Private Function MSTA1(ByVal x As Double, ByVal mp As Double) As Integer
        '  ===================================================
        '  Purpose: Determine the starting point for backward
        '           recurrence such that the magnitude of
        '           Jn(x) at that point is about 10^(-MP)
        '  Input :  x     --- Argument of Jn(x)
        '           MP    --- Value of magnitude
        '  Output:  MSTA1 --- Starting point
        ' ===================================================
        Dim A0 As Double, N0 As Double, F0 As Double, N1 As Double, F1 As Double, IT As Integer, NN As Double, F As Double
        A0 = Abs(x)
        N0 = Int(1.1 * A0) + 1
        F0 = ENVJ(N0, A0) - mp
        N1 = N0 + 5
        F1 = ENVJ(N1, A0) - mp
        For IT = 1 To 20
            NN = N1 - (N1 - N0) / (1 - F0 / F1)
            F = ENVJ(NN, A0) - mp
            If (Abs(NN - N1) < 1) Then Exit For
            N0 = N1
            F0 = F1
            N1 = NN
            F1 = F
        Next
        MSTA1 = NN
    End Function


    Private Function MSTA2(ByVal x As Double, ByVal n As Double, ByVal mp As Double) As Integer
        ' ===================================================
        ' Purpose: Determine the starting point for backward
        '         recurrence such that all Jn(x) has MP
        '         significant digits
        ' Input :  x  --- Argument of Jn(x)
        '          n  --- Order of Jn(x)
        '          MP --- Significant digit
        ' Output:  MSTA2 --- Starting point
        ' ===================================================
        Dim A0 As Double, HMP As Double, EJN As Double, OBJ As Double, N0 As Double, F0 As Double, N1 As Double, F1 As Double, IT As Integer, NN As Double, F As Double
        A0 = Abs(x)
        HMP = 0.5 * mp
        EJN = ENVJ(n, A0)
        If (EJN <= HMP) Then
            OBJ = mp
            N0 = Int(1.1 * A0) + 1 'bug for x<0.1 - VL, 2-8.2002
        Else
            OBJ = HMP + EJN
            N0 = n
        End If
        F0 = ENVJ(N0, A0) - OBJ
        N1 = N0 + 5
        F1 = ENVJ(N1, A0) - OBJ
        For IT = 1 To 20
            NN = N1 - (N1 - N0) / (1 - F0 / F1)
            F = ENVJ(NN, A0) - OBJ
            If (Abs(NN - N1) < 1) Then Exit For
            N0 = N1
            F0 = F1
            N1 = NN
            F1 = F
        Next
        MSTA2 = NN + 10
    End Function

    Private Function ENVJ(ByVal n As Double, ByVal x As Double) As Double
        ENVJ = 0.5 * Log10(6.28 * n) - n * Log10(1.36 * x / n)
    End Function

    Private Function Log10(ByVal x As Double) As Double
        Log10 = Log(x) / Log(10)
    End Function


    Sub IK01A(ByVal x As Double, ByRef BI0 As Double, ByRef DI0 As Double, ByRef BI1 As Double, ByRef DI1 As Double, ByRef BK0 As Double, ByRef DK0 As Double, ByRef BK1 As Double, ByRef DK1 As Double)
        '=========================================================
        'Purpose: Compute modified Bessel functions I0(x), I1(1),
        '         K0(x) and K1(x), and their derivatives
        'Input :  x   --- Argument ( x ò 0 )
        'Output:  BI0 --- I0(x)
        '         DI0 --- I0'(x)
        '         BI1 --- I1(x)
        '         DI1 --- I1'(x)
        '         BK0 --- K0(x)
        '         DK0 --- K0'(x)
        '         BK1 --- K1(x)
        '         DK1 --- K1'(x)
        '=========================================================
        Const EL As Double = 0.577215664901533
        Dim X2 As Double, r As Double, i As Integer, k As Integer, K0 As Double, CA As Double, XR As Double, CT As Double, W0 As Double, WW As Double, CB As Double, XR2 As Double

        Dim A0() As Double = {0.125, 0.0703125, _
                  0.0732421875, 0.11215209960938, _
                  0.22710800170898, 0.57250142097473, _
                  1.7277275025845, 6.0740420012735, _
                  24.380529699556, 110.01714026925, _
                  551.33589612202, 3038.0905109224}
        Dim B0() As Double = {-0.375, -0.1171875, _
              -0.1025390625, -0.14419555664063, _
              -0.2775764465332, -0.67659258842468, _
              -1.9935317337513, -6.8839142681099, _
              -27.248827311269, -121.59789187654, _
              -603.84407670507, -3302.2722944809}
        Dim A1() As Double = {0.125, 0.2109375, _
       1.0986328125, 11.775970458984, _
       214.61706161499, 5951.1522710323, _
       233476.45606175, 12312234.987631}

        X2 = x * x
        If (x = 0) Then
            BI0 = 1
            BI1 = 0
            BK0 = 1.0E+300
            BK1 = 1.0E+300
            DI0 = 0
            DI1 = 0.5
            DK0 = -1.0E+300
            DK1 = -1.0E+300
            Exit Sub
        ElseIf (x <= 18) Then
            BI0 = 1
            r = 1
            For k = 1 To 50
                r = 0.25 * r * X2 / (k * k)
                BI0 = BI0 + r
                If (Abs(r / BI0) < 0.000000000000001) Then Exit For
            Next
            BI1 = 1
            r = 1
            For k = 1 To 50
                r = 0.25 * r * X2 / (k * (k + 1))
                BI1 = BI1 + r
                If (Abs(r / BI1) < 0.000000000000001) Then Exit For
            Next
            BI1 = 0.5 * x * BI1
        Else

            K0 = 12
            If (x >= 35) Then K0 = 9
            If (x >= 50) Then K0 = 7
            CA = Exp(x) / Sqrt(2 * PI_ * x)
            BI0 = 1
            XR = 1 / x
            For k = 1 To K0
                i = k - 1
                BI0 = BI0 + A0(i) * XR ^ k
            Next
            BI0 = CA * BI0
            BI1 = 1
            For k = 1 To K0
                i = k - 1
                BI1 = BI1 + B0(i) * XR ^ k
            Next
            BI1 = CA * BI1
        End If
        If (x <= 9) Then
            CT = -(Log(x / 2) + EL)
            BK0 = 0
            W0 = 0
            r = 1
            For k = 1 To 50
                W0 = W0 + 1 / k
                r = 0.25 * r / (k * k) * X2
                BK0 = BK0 + r * (W0 + CT)
                If (Abs((BK0 - WW) / BK0) < 0.000000000000001) Then Exit For
                WW = BK0
            Next
            BK0 = BK0 + CT
        Else

            CB = 0.5 / x
            XR2 = 1 / X2
            BK0 = 1
            For k = 1 To 8
                i = k - 1
                BK0 = BK0 + A1(i) * XR2 ^ k
            Next
            BK0 = CB * BK0 / BI0
        End If
        BK1 = (1 / x - BI1 * BK0) / BI0
        DI0 = BI1
        DI1 = BI0 - BI1 / x
        DK0 = -BK1
        DK1 = -BK0 - BK1 / x

    End Sub

    Sub IKNA(ByVal n As Double, ByVal x As Double, ByRef NM As Double, ByRef BI() As Double, ByRef DI() As Double, ByRef BK() As Double, ByRef DK() As Double)
        ' ========================================================
        ' Purpose: Compute modified Bessel functions In(x) and
        '          Kn(x), and their derivatives
        ' Input:   x --- Argument of In(x) and Kn(x) ( x ò 0 )
        '          n --- Order of In(x) and Kn(x)
        ' Output:  BI(n) --- In(x)
        '          DI(n) --- In'(x)
        '          BK(n) --- Kn(x)
        '          DK(n) --- Kn'(x)
        '          NM --- Highest order computed
        ' Routines called:
        '      (1) IK01A for computing I0(x),I1(x),K0(x) & K1(x)
        '      (2) MSTA1 and MSTA2 for computing the starting
        '          point for backward recurrence
        ' ========================================================
        Dim k As Integer, BI0 As Double, DI0 As Double, BI1 As Double, DI1 As Double, BK0 As Double, DK0 As Double, BK1 As Double, DK1 As Double
        Dim H0 As Double, H1 As Double, h As Double, m As Double, F0 As Double, F1 As Double, F As Double, S0 As Double
        Dim G0 As Double, G1 As Double, G As Double
        ReDim BI(n), DI(n), BK(n), DK(n)
        NM = n
        If (x <= 1.0E-100) Then
            For k = 0 To n
                BI(k) = 0
                DI(k) = 0
                BK(k) = 1.0E+300
                DK(k) = -1.0E+300
            Next
            BI(0) = 1
            DI(1) = 0.5
            Exit Sub
        End If
        Call IK01A(x, BI0, DI0, BI1, DI1, BK0, DK0, BK1, DK1)
        BI(0) = BI0
        BI(1) = BI1
        BK(0) = BK0
        BK(1) = BK1
        DI(0) = DI0
        DI(1) = DI1
        DK(0) = DK0
        DK(1) = DK1
        If (n <= 1) Then Exit Sub
        If (x > 40 And n < Int(0.25 * x)) Then
            H0 = BI0
            H1 = BI1
            For k = 2 To n
                h = -2 * (k - 1) / x * H1 + H0
                BI(k) = h
                H0 = H1
                H1 = h
            Next
        Else
            m = MSTA1(x, 200)
            If (m < n) Then
                NM = m
            Else
                m = MSTA2(x, n, 15)
            End If
            F0 = 0
            F1 = 1.0E-100
            For k = m To 0 Step -1
                F = 2 * (k + 1) * F1 / x + F0
                If (k <= NM) Then BI(k) = F
                F0 = F1
                F1 = F
            Next
            S0 = BI0 / F
            For k = 0 To NM
                BI(k) = S0 * BI(k)
            Next
        End If
        G0 = BK0
        G1 = BK1
        For k = 2 To NM
            G = 2 * (k - 1) / x * G1 + G0
            BK(k) = G
            G0 = G1
            G1 = G
        Next
        For k = 2 To NM
            DI(k) = BI(k - 1) - k / x * BI(k)
            DK(k) = -BK(k - 1) - k / x * BK(k)
        Next
    End Sub

    Sub CISIA(ByVal x As Double, ByRef CI As Double, ByRef SI As Double)
        '=============================================
        ' Purpose: Compute cosine and sine integrals
        '          Si(x) and Ci(x)  ( x ò 0 )
        ' Input :  x  --- Argument of Ci(x) and Si(x)
        ' Output:  CI --- Ci(x)
        '          SI --- Si(x)
        '=============================================
        Dim BJ(101) As Double, p2 As Double, EL As Double, EPS As Double, X2 As Double, XR As Double, k As Integer, m As Double
        Dim XA0 As Double, XA1 As Double, XA As Double, XS As Double, XG1 As Double, XG2 As Double
        Dim XCS As Double, XSS As Double, XF As Double, XG As Double

        p2 = PI_ / 2
        EL = 0.577215664901533
        EPS = 0.000000000000001
        X2 = x * x
        If (x = 0) Then
            CI = -1.0E+300
            SI = 0
        ElseIf (x <= 16) Then
            XR = -0.25 * X2
            CI = EL + Log(x) + XR
            For k = 2 To 40
                XR = -0.5 * XR * (k - 1) / (k * k * (2 * k - 1)) * X2
                CI = CI + XR
                If (Abs(XR) < Abs(CI) * EPS) Then Exit For
            Next
            XR = x
            SI = x
            For k = 1 To 40
                XR = -0.5 * XR * (2 * k - 1) / k / (4 * k * k + 4 * k + 1) * X2
                SI = SI + XR
                If (Abs(XR) < Abs(SI) * EPS) Then Exit For
            Next
        ElseIf (x <= 32) Then
            m = Int(47.2 + 0.82 * x)
            XA1 = 0
            XA0 = 1.0E-100
            For k = m To 1 Step -1
                XA = 4 * k * XA0 / x - XA1
                BJ(k) = XA
                XA1 = XA0
                XA0 = XA
            Next
            XS = BJ(1)
            For k = 3 To m Step 2
                XS = XS + 2 * BJ(k)
            Next
            BJ(1) = BJ(1) / XS
            For k = 2 To m
                BJ(k) = BJ(k) / XS
            Next
            XR = 1
            XG1 = BJ(1)
            For k = 2 To m
                XR = 0.25 * XR * (2 * k - 3) ^ 2 / ((k - 1) * (2 * k - 1) ^ 2) * x
                XG1 = XG1 + BJ(k) * XR
            Next
            XR = 1
            XG2 = BJ(1)
            For k = 2 To m
                XR = 0.25 * XR * (2 * k - 5) ^ 2 / ((k - 1) * (2 * k - 3) ^ 2) * x
                XG2 = XG2 + BJ(k) * XR
            Next
            XCS = Cos(x / 2)
            XSS = Sin(x / 2)
            CI = EL + Log(x) - x * XSS * XG1 + 2 * XCS * XG2 - 2 * XCS * XCS
            SI = x * XCS * XG1 + 2 * XSS * XG2 - Sin(x)
        Else
            XR = 1
            XF = 1
            For k = 1 To 9
                XR = -2 * XR * k * (2 * k - 1) / X2
                XF = XF + XR
            Next
            XR = 1 / x
            XG = XR
            For k = 1 To 8
                XR = -2 * XR * (2 * k + 1) * k / X2
                XG = XG + XR
            Next
            CI = XF * Sin(x) / x - XG * Cos(x) / x
            SI = p2 - XF * Cos(x) / x - XG * Sin(x) / x
        End If
    End Sub

    Sub FCS(ByVal x As Double, ByRef c As Double, ByRef s As Double)
        ' =================================================
        '  Purpose: Compute Fresnel integrals C(x) and S(x)
        '  Input :  x --- Argument of C(x) and S(x)
        '  Output:  C --- C(x)
        '           S --- S(x)
        ' =================================================
        Const EPS As Double = 0.000000000000001
        Dim XA As Double, PX As Double, t As Double, T0 As Double, T1 As Double, T2 As Double, r As Double, k As Integer, m As Double, SU As Double, F As Double, F0 As Double, F1 As Double, Q As Double, G As Double

        XA = Abs(x)
        PX = PI_ * XA
        t = 0.5 * PX * XA
        T2 = t * t
        If (XA = 0) Then
            c = 0
            s = 0
        ElseIf (XA < 2.5) Then
            r = XA
            c = r
            For k = 1 To 50
                r = -0.5 * r * (4 * k - 3) / k / (2 * k - 1) / (4 * k + 1) * T2
                c = c + r
                If (Abs(r) < Abs(c) * EPS) Then Exit For
            Next
            s = XA * t / 3
            r = s
            For k = 1 To 50
                r = -0.5 * r * (4 * k - 1) / k / (2 * k + 1) / (4 * k + 3) * T2
                s = s + r
                If (Abs(r) < Abs(s) * EPS) Then GoTo Label40
            Next
        ElseIf (XA < 4.5) Then
            m = Int(42 + 1.75 * t)
            SU = 0
            c = 0
            s = 0
            F1 = 0
            F0 = 1.0E-100
            For k = m To 0 Step -1
                F = (2 * k + 3) * F0 / t - F1
                If (k = Int(k / 2) * 2) Then
                    c = c + F
                Else
                    s = s + F
                End If
                SU = SU + (2 * k + 1) * F * F
                F1 = F0
                F0 = F
            Next
            Q = Sqrt(SU)
            c = c * XA / Q
            s = s * XA / Q
        Else
            r = 1
            F = 1
            For k = 1 To 20
                r = -0.25 * r * (4 * k - 1) * (4 * k - 3) / T2
                F = F + r
            Next
            r = 1 / (PX * XA)
            G = r
            For k = 1 To 12
                r = -0.25 * r * (4 * k + 1) * (4 * k - 1) / T2
                G = G + r
            Next
            T0 = t - Int(t / (2 * PI_)) * 2 * PI_
            c = 0.5 + (F * Sin(T0) - G * Cos(T0)) / PX
            s = 0.5 - (F * Cos(T0) + G * Sin(T0)) / PX
        End If
        Exit Sub
Label40:
        If (x < 0) Then
            c = -c
            s = -s
        End If

    End Sub

    Sub HYGFX(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal x As Double, ByRef hf As Double, ByRef ErrorMsg As String)
        ' ====================================================
        '       Purpose: Compute hypergeometric function F(a,b,c,x)
        '       Input :  a --- Parameter
        '                b --- Parameter
        '                c --- Parameter, c <> 0,-1,-2,...
        '                x --- Argument   ( x < 1 )
        '       Output:  HF --- F(a,b,c,x)
        '====================================================
        Dim L0 As Boolean, L1 As Boolean, L2 As Boolean, L3 As Boolean, L4 As Boolean, L5 As Boolean
        Dim EL As Double, EPS As Double, GC As Double, GCAB As Double, GCA As Double, GCB As Double, G0 As Double, G1 As Double, G2 As Double
        Dim G3 As Double, NM As Double, r As Double, j As Integer, k As Integer, AA As Double, BB As Double, x1 As Double, GM As Double, m As Double, GA As Double, GB As Double
        Dim GAM As Double, GBM As Double, PA As Double, PB As Double, RM As Double, F0 As Double, R0 As Double, R1 As Double, SP0 As Double, SP As Double, C0 As Double
        Dim C1 As Double, F1 As Double, SM As Double, RP As Double, HW As Double, GABC As Double, A0 As Double

        EL = 0.577215664901533
        EPS = 0.000000000000001
        L0 = (c = Int(c)) And (c < 0)
        L1 = ((1 - x) < EPS) And ((c - a - b) <= 0)
        L2 = (a = Int(a)) And (a < 0)
        L3 = (b = Int(b)) And (b < 0)
        L4 = (c - a = Int(c - a)) And (c - a <= 0)
        L5 = (c - b = Int(c - b)) And (c - b <= 0)
        If (L0 Or L1) Then
            ErrorMsg = "The hypergeometric series is divergent"
            Exit Sub
        End If
        If (x > 0.95) Then EPS = 0.00000001
        If (x = 0 Or a = 0 Or b = 0) Then
            hf = 1
            Exit Sub
        ElseIf ((1 - x = EPS) And (c - a - b) > 0) Then
            Call HGamma(c, GC)
            Call HGamma(c - a \ -b, GCAB)
            Call HGamma(c - a, GCA)
            Call HGamma(c - b, GCB)
            hf = GC * GCAB / (GCA * GCB)
            Exit Sub
        ElseIf ((1 + x <= EPS) And (Abs(c - a + b - 1) <= EPS)) Then
            G0 = Sqrt(PI_) * 2 ^ (-a)
            Call HGamma(c, G1)
            Call HGamma(1 + a / 2 - b, G2)
            Call HGamma(0.5 + 0.5 * a, G3)
            hf = G0 * G1 / (G2 * G3)
            Exit Sub
        ElseIf (L2 Or L3) Then
            If (L2) Then NM = Int(Abs(a))
            If (L3) Then NM = Int(Abs(b))
            hf = 1
            r = 1
            For k = 1 To NM
                r = r * (a + k - 1) * (b + k - 1) / (k * (c + k - 1)) * x
                hf = hf + r
            Next k
            Exit Sub
        ElseIf (L4 Or L5) Then
            If (L4) Then NM = Int(Abs(c - a))
            If (L5) Then NM = Int(Abs(c - b))
            hf = 1
            r = 1
            For k = 1 To NM
                r = r * (c - a + k - 1) * (c - b + k - 1) / (k * (c + k - 1)) * x
                hf = hf + r
            Next k
            hf = (1 - x) ^ (c - a - b) * hf
            Exit Sub
        End If
        AA = a
        BB = b
        x1 = x
        If (x < 0) Then
            x = x / (x - 1)
            If (c > a And b < a And b > 0) Then
                a = BB
                b = AA
            End If
            b = c - b
        End If
        If (x >= 0.75) Then
            GM = 0
            If (Abs(c - a - b - Int(c - a - b)) < 0.000000000000001) Then
                m = Int(c - a - b)
                Call HGamma(a, GA)
                Call HGamma(b, GB)
                Call HGamma(c, GC)
                Call HGamma(a + m, GAM)
                Call HGamma(b + m, GBM)
                Call HDigamma(a, PA)
                Call HDigamma(b, PB)
                If (m <> 0) Then GM = 1
                For j = 1 To Abs(m) - 1
                    GM = GM * j
                Next j
                RM = 1
                For j = 1 To Abs(m)
                    RM = RM * j
                Next j
                F0 = 1
                R0 = 1
                R1 = 1
                SP0 = 0
                SP = 0
                If (m >= 0) Then
                    C0 = GM * GC / (GAM * GBM)
                    C1 = -GC * (x - 1) ^ m / (GA * GB * RM)
                    For k = 1 To m - 1
                        R0 = R0 * (a + k - 1) * (b + k - 1) / (k * (k - m)) * (1 - x)
                        F0 = F0 + R0
                    Next k
                    For k = 1 To m
                        SP0 = SP0 + 1 / (a + k - 1) + 1 / (b + k - 1) - 1 / k
                    Next k
                    F1 = PA + PB + SP0 + 2 * EL + Log(1 - x)
                    For k = 1 To 250
                        SP = SP + (1 - a) / (k * (a + k - 1)) + (1 - b) / (k * (b + k - 1))
                        SM = 0
                        For j = 1 To m
                            SM = SM + (1 - a) / ((j + k) * (a + j + k - 1)) + 1 / (b + j + k - 1)
                        Next j
                        RP = PA + PB + 2 * EL + SP + SM + Log(1 - x)
                        R1 = R1 * (a + m + k - 1) * (b + m + k - 1) / (k * (m + k)) * (1 - x)
                        F1 = F1 + R1 * RP
                        If (Abs(F1 - HW) < Abs(F1) * EPS) Then GoTo 60
                        HW = F1
                    Next k
60:                 hf = F0 * C0 + F1 * C1
                ElseIf (m < 0) Then
                    m = -m
                    C0 = GM * GC / (GA * GB * (1 - x) ^ m)
                    C1 = -(-1) ^ m * GC / (GAM * GBM * RM)
                    For k = 1 To m - 1
                        R0 = R0 * (a - m + k - 1) * (b - m + k - 1) / (k * (k - m)) * (1 - x)
                        F0 = F0 + R0
                    Next k
                    For k = 1 To m
                        SP0 = SP0 + 1 / k
                    Next k
                    F1 = PA + PB - SP0 + 2 * EL + Log(1 - x)
                    For k = 1 To 250
                        SP = SP + (1 - a) / (k * (a + k - 1)) + (1 - b) / (k * (b + k - 1))
                        SM = 0
                        For j = 1 To m
                            SM = SM + 1 / (j + k)
                        Next j
                        RP = PA + PB + 2 * EL + SP - SM + Log(1 - x)
                        R1 = R1 * (a + k - 1) * (b + k - 1) / (k * (m + k)) * (1 - x)
                        F1 = F1 + R1 * RP
                        If (Abs(F1 - HW) < (Abs(F1) * EPS)) Then GoTo 85
                        HW = F1
                    Next k
85:                 hf = F0 * C0 + F1 * C1
                End If
            Else
                Call HGamma(a, GA)
                Call HGamma(b, GB)
                Call HGamma(c, GC)
                Call HGamma(c - a, GCA)
                Call HGamma(c - b, GCB)
                Call HGamma(c - a - b, GCAB)
                Call HGamma(a + b - c, GABC)
                C0 = GC * GCAB / (GCA * GCB)
                C1 = GC * GABC / (GA * GB) * (1 - x) ^ (c - a - b)
                hf = 0
                R0 = C0
                R1 = C1
                For k = 1 To 250
                    R0 = R0 * (a + k - 1) * (b + k - 1) / (k * (a + b - c + k)) * (1 - x)
                    R1 = R1 * (c - a + k - 1) * (c - b + k - 1) / (k * (c - a - b + k)) * (1 - x)
                    hf = hf + R0 + R1
                    If (Abs(hf - HW) < (Abs(hf) * EPS)) Then GoTo 95
                    HW = hf
                Next k
95:             hf = hf + C0 + C1
            End If
        Else
            A0 = 1
            If ((c > a) And (c < (2 * a)) And (c > b) And (c < 2 * b)) Then
                A0 = (1 - x) ^ (c - a - b)
                a = c - a
                b = c - b
            End If
            hf = 1
            r = 1
            For k = 1 To 250
                r = r * (a + k - 1) * (b + k - 1) / (k * (c + k - 1)) * x
                hf = hf + r
                If (Abs(hf - HW) <= (Abs(hf) * EPS)) Then GoTo 105
                HW = hf
            Next k
105:        hf = A0 * hf
        End If
        If (x1 < 0) Then
            x = x1
            C0 = 1 / (1 - x) ^ AA
            hf = C0 * hf
        End If
        a = AA
        b = BB
        If (k > 120) Then
            ErrorMsg = "Warning! You should check the accuracy"
            Exit Sub
        End If
    End Sub

    Sub INCOG(ByVal a As Double, ByVal x As Double, ByRef GIN As Double, ByRef GIM As Double, ByRef GIP As Double, ByRef MSG As String)
        ' ===================================================
        '       Purpose: Compute the incomplete gamma function
        '        c R(a, x), â(a, x) And P(a, x)
        '       Input :  a   --- Parameter ( a < 170 )
        '                x   - --Argument
        '       Output:        GIN ---R(a, x)
        '                      GIM - --â(a, x)
        '                      GIP - --P(a, x)
        '       Routine called: GAMMA for computing â(x)
        '===================================================
        Dim k As Integer, XAM As Double, GA As Double, s As Double, r As Double, T0 As Double
        XAM = -x + a * Log(x)
        If (XAM > 700 Or a > 170) Then
            MSG = "a and/or x too large"
            Exit Sub
        End If
        If (x = 0) Then
            GIN = 0
            Call HGamma(a, GA)
            GIM = GA
            GIP = 0
        ElseIf (x <= 1 + a) Then
            s = 1 / a
            r = s
            For k = 1 To 60
                r = r * x / (a + k)
                s = s + r
                If (Abs(r / s) < 10 ^ -15) Then Exit For
            Next k
            GIN = Exp(XAM) * s
            Call HGamma(a, GA)
            GIP = GIN / GA
            GIM = GA - GIN
        ElseIf (x > 1 + a) Then
            T0 = 0
            For k = 60 To 1 Step -1
                T0 = (k - a) / (1 + k / (x + T0))
            Next k
            GIM = Exp(XAM) / (x + T0)
            Call HGamma(a, GA)
            GIN = GA - GIM
            GIP = 1 - GIM / GA
        End If
    End Sub

    Sub INCOB(ByVal a As Double, ByVal b As Double, ByVal x As Double, ByRef BIX As Double)
        ' ========================================================
        '      Purpose: Compute the incomplete beta function Ix(a,b)
        '       Input :  a --- Parameter
        '                b - --Parameter
        '                x --- Argument ( 0 ó x ó 1 )
        '       Output:        BIX ---Ix(a, b)
        '       Routine called: BETA for computing beta function B(p,q)
        ' ========================================================
        Dim DK(51) As Double, FK(51) As Double, k As Integer, S0 As Double, T1 As Double, T2 As Double, TA As Double, TB As Double, BT As Double
        S0 = (a + 1) / (a + b + 2)
        Call HBeta(a, b, BT)
        If (x <= S0) Then
            For k = 1 To 20
                DK(2 * k) = k * (b - k) * x / (a + 2 * k - 1) / (a + 2 * k)
            Next k
            For k = 0 To 20
                DK(2 * k + 1) = -(a + k) * (a + b + k) * x / (a + 2 * k) / (a + 2 * k + 1)
            Next k
            T1 = 0
            For k = 20 To 1 Step -1
                T1 = DK(k) / (1 + T1)
            Next k
            TA = 1 / (1 + T1)
            BIX = x ^ a * (1 - x) ^ b / (a * BT) * TA
        Else
            For k = 1 To 20
                FK(2 * k) = k * (a - k) * (1 - x) / (b + 2 * k - 1) / (b + 2 * k)
            Next k
            For k = 0 To 20
                FK(2 * k + 1) = -(b + k) * (a + b + k) * (1 - x) / (b + 2 * k) / (b + 2 * k + 1)
            Next k
            T2 = 0
            For k = 20 To 1 Step -1
                T2 = FK(k) / (1 + T2)
            Next k
            TB = 1 / (1 + T2)
            BIX = 1 - x ^ a * (1 - x) ^ b / (b * BT) * TB
        End If
    End Sub

    Sub AIRYB(ByVal x As Double, ByRef AI As Double, ByRef BI As Double, ByRef AD As Double, ByRef BD As Double)
        '=======================================================
        '       Purpose: Compute Airy functions and their derivatives
        '       Input:   x  --- Argument of Airy function
        '       Output:  AI --- Ai(x)
        '                BI --- Bi(x)
        '                AD --- Ai'(x)
        '                BD --- Bi'(x)
        '=======================================================
        Dim CK(41) As Double, DK(41) As Double
        Dim EPS As Double, C1 As Double, C2 As Double, SR3 As Double, XA As Double, XQ As Double, XM As Double, FX As Double, r As Double, GX As Double, DF As Double, DG As Double
        Dim XE As Double, XR1 As Double, XAR As Double, XF As Double, RP As Double, KM As Double
        Dim SAI As Double, SAD As Double, SBI As Double, SBD As Double, XP1 As Double, XCS As Double, XSS As Double, SSA As Double, SDA As Double, XR2 As Double, SSB As Double, SDB As Double
        Dim k As Integer

        EPS = 0.000000000000001
        C1 = 0.355028053887817
        C2 = 0.258819403792807
        SR3 = 1.73205080756888
        XA = Abs(x)
        XQ = Sqrt(XA)
        If (x > 0) Then XM = 5
        If (x <= 0) Then XM = 8
        If (x = 0) Then
            AI = C1
            BI = SR3 * C1
            AD = -C2
            BD = SR3 * C2
            Exit Sub
        End If
        If (XA <= XM) Then
            FX = 1
            r = 1
            For k = 1 To 40
                r = r * x / (3 * k) * x / (3 * k - 1) * x
                FX = FX + r
                If (Abs(r) < Abs(FX) * EPS) Then Exit For
            Next k
            GX = x
            r = x
            For k = 1 To 40
                r = r * x / (3 * k) * x / (3 * k + 1) * x
                GX = GX + r
                If (Abs(r) < Abs(GX) * EPS) Then Exit For
            Next k
            AI = C1 * FX - C2 * GX
            BI = SR3 * (C1 * FX + C2 * GX)
            DF = 0.5 * x * x
            r = DF
            For k = 1 To 40
                r = r * x / (3 * k) * x / (3 * k + 2) * x
                DF = DF + r
                If (Abs(r) < Abs(DF) * EPS) Then Exit For
            Next k
            DG = 1
            r = 1
            For k = 1 To 40
                r = r * x / (3 * k) * x / (3 * k - 2) * x
                DG = DG + r
                If (Abs(r) < Abs(DG) * EPS) Then Exit For
            Next k
            AD = C1 * DF - C2 * DG
            BD = SR3 * (C1 * DF + C2 * DG)
        Else
            XE = XA * XQ / 1.5
            XR1 = 1 / XE
            XAR = 1 / XQ
            XF = Sqrt(XAR)
            RP = 0.564189583547756
            r = 1
            For k = 1 To 40
                r = r * (6 * k - 1) / 216 * (6 * k - 3) / k * (6 * k - 5) / (2 * k - 1)
                CK(k) = r
                DK(k) = -(6 * k + 1) / (6 * k - 1) * CK(k)
            Next k
            KM = Int(24.5 - XA)
            If (XA < 6) Then KM = 14
            If (XA > 15) Then KM = 10
            If (x > 0) Then
                SAI = 1
                SAD = 1
                r = 1
                For k = 1 To KM
                    r = -r * XR1
                    SAI = SAI + CK(k) * r
                    SAD = SAD + DK(k) * r
                Next k
                SBI = 1
                SBD = 1
                r = 1
                For k = 1 To KM
                    r = r * XR1
                    SBI = SBI + CK(k) * r
                    SBD = SBD + DK(k) * r
                Next k
                XP1 = Exp(-XE)
                AI = 0.5 * RP * XF * XP1 * SAI
                BI = RP * XF / XP1 * SBI
                AD = -0.5 * RP / XF * XP1 * SAD
                BD = RP / XF / XP1 * SBD
            Else
                XCS = Cos(XE + PI_ / 4)
                XSS = Sin(XE + PI_ / 4)
                SSA = 1
                SDA = 1
                r = 1
                XR2 = 1 / (XE * XE)
                For k = 1 To KM
                    r = -r * XR2
                    SSA = SSA + CK(2 * k) * r
                    SDA = SDA + DK(2 * k) * r
                Next k
                SSB = CK(1) * XR1
                SDB = DK(1) * XR1
                r = XR1
                For k = 1 To KM
                    r = -r * XR2
                    SSB = SSB + CK(2 * k + 1) * r
                    SDB = SDB + DK(2 * k + 1) * r
                Next k
                AI = RP * XF * (XSS * SSA - XCS * SSB)
                BI = RP * XF * (XCS * SSA + XSS * SSB)
                AD = -RP / XF * (XCS * SDA + XSS * SDB)
                BD = RP / XF * (XSS * SDA - XCS * SDB)
            End If
        End If

    End Sub


    Sub ELIT(ByVal HK As Double, ByVal phi As Double, ByRef FE As Double, ByRef EE As Double)
        ' ==================================================
        '       Purpose: Compute complete and incomplete elliptic
        '                integrals F(k,phi) and E(k,phi)
        '       Input  : HK  --- Modulus k ( 0 ó k ó 1 )
        '                Phi --- Argument ( in degrees )
        '       Output : FE  --- F(k,phi)
        '                EE  --- E(k,phi)
        ' ==================================================
        Dim G1 As Double, A0 As Double, B0 As Double, A1 As Double, B1 As Double, C1 As Double, D0 As Double, D1 As Double, r As Double, FAC As Double, CK As Double, CE As Double
        Dim n As Integer

        G1 = 0
        A0 = 1
        B0 = Sqrt(1 - HK * HK)
        D0 = (PI_ / 180) * phi
        r = HK * HK
        If (HK = 1 And phi = 90) Then
            FE = 1.0E+300
            EE = 1
        ElseIf (HK = 1) Then
            FE = Log((1 + Sin(D0)) / Cos(D0))
            EE = Sin(D0)
        Else
            FAC = 1
            For n = 1 To 40
                A1 = (A0 + B0) / 2
                B1 = Sqrt(A0 * B0)
                C1 = (A0 - B0) / 2
                FAC = 2 * FAC
                r = r + FAC * C1 * C1
                If (phi <> 90) Then
                    D1 = D0 + Atan((B0 / A0) * Tan(D0))
                    G1 = G1 + C1 * Sin(D1)
                    D0 = D1 + PI_ * Int(D1 / PI_ + 0.5)
                End If
                A0 = A1
                B0 = B1
                If (C1 < 0.0000001) Then Exit For
            Next n
            CK = PI_ / (2 * A1)
            CE = PI_ * (2 - r) / (4 * A1)
            If (phi = 90) Then
                FE = CK
                EE = CE
            Else
                FE = D1 / (FAC * A1)
                EE = FE * CE / CK + G1
            End If
        End If
    End Sub


    '-------------------------------------------------------------------------------
    ' Legendre's polynomials
    '-------------------------------------------------------------------------------
    Sub PLegendre(ByVal x As Double, ByVal n As Double, ByRef y As Double)
        Dim i As Integer, p0 As Double, p1 As Double, p2 As Double
        p0 = 0 : p1 = 1 : p2 = p1
        For i = 1 To n
            p2 = (2 * i - 1) / i * x * p1 - (i - 1) / i * p0
            p0 = p1
            p1 = p2
        Next i
        y = p2
    End Sub

    '-------------------------------------------------------------------------------
    ' Hermite's polynomials
    '-------------------------------------------------------------------------------
    Sub PHermite(ByVal x As Double, ByVal n As Double, ByRef y As Double)
        Dim i As Integer, p0, p1, p2
        p0 = 0 : p1 = 1 : p2 = p1
        For i = 1 To n
            p2 = 2 * x * p1 - 2 * (i - 1) * p0
            p0 = p1
            p1 = p2
        Next i
        y = p2
    End Sub

    '-------------------------------------------------------------------------------
    ' Laguerre's polynomials
    '-------------------------------------------------------------------------------
    Sub PLaguerre(ByVal x As Double, ByVal n As Double, ByRef y As Double)
        Dim i As Integer, p0 As Double, p1 As Double, p2 As Double
        p0 = 0 : p1 = 1 : p2 = p1
        For i = 1 To n
            p2 = (2 * i - 1 - x) * p1 - (i - 1) ^ 2 * p0
            p0 = p1
            p1 = p2
        Next i
        y = p2
    End Sub

    '-------------------------------------------------------------------------------
    ' Chebycev's polynomials
    '-------------------------------------------------------------------------------
    Sub PChebycev(ByVal x As Double, ByVal n As Double, ByRef y As Double)
        Dim i As Integer, p0 As Double, p1 As Double, p2 As Double
        If n = 0 Then y = 1 : Exit Sub
        If n = 1 Then y = x : Exit Sub
        p0 = 1 : p1 = x
        For i = 1 To n - 1
            p2 = 2 * x * p1 - p0
            p0 = p1
            p1 = p2
        Next i
        y = p2
    End Sub

    '------------------------------------------------------------------------------------
    ' special periodic functions
    '-----------------------------------------------------------------------------------
    Private Function MopUp(ByVal x As Double) As Double
        If Abs(x) < 0.00000000000005 Then x = 0
        MopUp = x
    End Function
    'triangular wave
    Function WAVE_TRI(ByVal t As Double, ByVal p As Double) As Double
        WAVE_TRI = MopUp(4 * Abs(Int(t / p + 1 / 2) - t / p) - 1)
    End Function
    'square wave
    Function WAVE_SQR(ByVal t As Double, ByVal p As Double) As Double
        WAVE_SQR = MopUp(-2 * Int(t / p + 1 / 2) + 2 * Int(t / p) + 1)
    End Function
    'rectangular wave
    Function WAVE_RECT(ByVal t As Double, ByVal p As Double, ByVal duty_cicle As Double) As Double
        WAVE_RECT = MopUp(-2 * Int(t / p - duty_cicle) + 2 * Int(t / p) - 1)
    End Function
    'trapez. wave
    Function WAVE_TRAPEZ(ByVal t As Double, ByVal p As Double, ByVal duty_cicle As Double) As Double
        Dim y As Double
        y = 1 / duty_cicle * (2 * Abs(Int(t / p + 1 / 2) - t / p) - Abs(2 * Int(-duty_cicle / (2 * p) + t / p + 1 / 2) + (duty_cicle - 2 * t) / p))
        WAVE_TRAPEZ = MopUp(y)
    End Function
    'Saw wave
    Function WAVE_SAW(ByVal t As Double, ByVal p As Double) As Double
        WAVE_SAW = MopUp(2 * t / p - 2 * Int(t / p + 1 / 2))
    End Function
    'Rampa wave
    Function WAVE_RAISE(ByVal t As Double, ByVal p As Double) As Double
        WAVE_RAISE = MopUp(t / p - Int(t / p))
    End Function
    'Linear wave
    Function WAVE_LIN(ByVal t As Double, ByVal p As Double, ByVal duty_cicle As Double) As Double
        Dim y As Double
        y = (p * Int(t / p - duty_cicle) ^ 2 + (2 * duty_cicle * p + p - 2 * t) * Int(t / p - duty_cicle) - p * Int(-duty_cicle) ^ 2 - p * (2 * duty_cicle + 1) _
            * Int(-duty_cicle) - p * Int(t / p) ^ 2 + (2 * t - p) * Int(t / p) + duty_cicle * (duty_cicle * p - p - 2 * t)) / (duty_cicle * p * (1 - duty_cicle))
        WAVE_LIN = MopUp(y)
    End Function
    'rectangular pulse wave
    Function WAVE_PULSE(ByVal t As Double, ByVal p As Double, ByVal duty_cicle As Double) As Double
        WAVE_PULSE = MopUp(-Int(t / p - duty_cicle) + Int(t / p))
    End Function
    'steps wave
    Function WAVE_STEPS(ByVal t As Double, ByVal p As Double, ByVal n As Double) As Double
        WAVE_STEPS = MopUp(1 / (n - 1) * (Int(n * t / p) - n * Int(t / p)))
    End Function
    'exponential pulse wave
    Function WAVE_EXP(ByVal t As Double, ByVal p As Double, ByVal a As Double) As Double
        WAVE_EXP = MopUp(Exp(-a * t / p + a * Int(t / p)))
    End Function
    'exponential bipolar pulse wave
    Function WAVE_EXPB(ByVal t As Double, ByVal p As Double, ByVal a As Double) As Double
        WAVE_EXPB = MopUp(Exp(-a * t / p + a * Int(t / p)) - Exp(-a * (t / p + 1 / 2) + a * Int(t / p + 1 / 2)))
    End Function
    'filtered pulse wave
    Function WAVE_PULSEF(ByVal t As Double, ByVal p As Double, ByVal a As Double) As Double
        WAVE_PULSEF = (-Int(t / p + 1 / 2) + Int(t / p) + 1 - (Exp(-a * t / p + a * Int(t / p)) - Exp(-a * (t / p + 1 / 2) + a * Int(t / p + 1 / 2))))
    End Function
    'ringing wave
    Function WAVE_RING(ByVal t As Double, ByVal p As Double, ByVal a As Double, ByVal omega As Double) As Double
        WAVE_RING = (-Exp(a * Int(t / p) - a * t / p) * Sin(2 * PI_ * omega * Int(t / p) - 2 * PI_ * omega * t / p))
    End Function
    'parabolic pulse wave
    Function WAVE_PARAB(ByVal t As Double, ByVal p As Double) As Double
        WAVE_PARAB = MopUp((2 * Abs(Int(t / p + 1 / 2) - t / p)) ^ 2)
    End Function
    'ripple wave
    Function WAVE_RIPPLE(ByVal t As Double, ByVal p As Double, ByVal a As Double) As Double
        Dim x As Double, y As Double, r As Double
        y = Abs(Cos(PI_ / p * t))
        x = Exp(a * Int(t / p) - a * t / p)
        If x > y Then r = x Else r = y
        WAVE_RIPPLE = r
    End Function
    'rectifire wave
    Function WAVE_SINREC(ByVal t As Double, ByVal p As Double) As Double
        WAVE_SINREC = Abs(Sin(PI_ * t / p))
    End Function
    'Amplitude modulation
    Function WAVE_AM(ByVal t As Double, ByVal fo As Double, ByVal fm As Double, ByVal m As Double) As Double
        WAVE_AM = (1 + m * Sin(2 * PI_ * fm * t)) * Sin(2 * PI_ * fo * t)
    End Function
    'frequecy modulation
    Function WAVE_FM(ByVal t As Double, ByVal fo As Double, ByVal fm As Double, ByVal m As Double) As Double
        WAVE_FM = Sin(2 * PI_ * fo * (1 + m * Sin(2 * PI_ * fm * t)) * t)
    End Function


    '***********  End of Library for computation of Special Functions ******************


#End Region


End Class
