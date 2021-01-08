namespace ExactOnline.Client.Models.Manufacturing
{
    public class MaterialPlanCalculator
    {
		/// <summary>Fixed calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public FixedCalculator FixedCalculator { get; set; } = new FixedCalculator();
		/// <summary>Materials per piece calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public MaterialsPerPieceCalculator MaterialsPerPieceCalculator { get; set; } = new MaterialsPerPieceCalculator();
		/// <summary>Pieces per material calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public PiecesPerMaterialCalculator PiecesPerMaterialCalculator { get; set; } = new PiecesPerMaterialCalculator();
		/// <summary>Bar calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public BarCalculator BarCalculator { get; set; } = new BarCalculator();
		/// <summary>Sheet calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public SheetCalculator SheetCalculator { get; set; } = new SheetCalculator();
		/// <summary>Coil wire length calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public CoilWireLengthCalculator CoilWireLengthCalculator { get; set; } = new CoilWireLengthCalculator();
		/// <summary>Coil wire weight calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public CoilWireWeightCalculator CoilWireWeightCalculator { get; set; } = new CoilWireWeightCalculator();
		/// <summary>Volume calculator</summary>
		[SDKFieldType(FieldType.ReadOnly)]
		public VolumeCalculator VolumeCalculator { get; set; } = new VolumeCalculator();
    }

    public class FixedCalculator
    {
        /// <summary>Fixed quantity</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? FixedQuantity { get; set; }
        /// <summary>Pieces per make item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesPerMakeItem { get; set; }
    }

    public class MaterialsPerPieceCalculator
    {
        /// <summary>Materials per piece</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? MaterialsPerPiece { get; set; }
        /// <summary>Pieces per make item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesPerMakeItem { get; set; }
    }

    public class PiecesPerMaterialCalculator
    {
        /// <summary>Pieces per material</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesPerMaterial { get; set; }
        /// <summary>Pieces per make item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesPerMakeItem { get; set; }
    }

    public class CalculatorBase
    {
        /// <summary>Pieces per material</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ItemStockUnit { get; set; }
        /// <summary>Shape unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ShapeUnit { get; set; }
        /// <summary>Conversion unit factor</summary>
        public double? ConversionUnitFactor { get; set; }
        /// <summary>Conversion unit factor type - 1 := 1 stockUnit = X shapeunits, 2 := 1 Shape Unit = X Stock Units</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? ConversionUnitFactorType { get; set; }
        /// <summary>Conversion unit description</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string ConversionUnitDescription { get; set; }
        /// <summary>Pieces per make item</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesPerMakeItem { get; set; }
    }

    public class BarCalculator : CalculatorBase
    {
        /// <summary>Bar length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string BarLengthUnit { get; set; }

        /// <summary>Bar length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? BarLength { get; set; }

        /// <summary>Bar end</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? BarEnd { get; set; }

        /// <summary>Weight per length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string WeightPerLengthUnit { get; set; }

        /// <summary>Weight per length unit factor</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? WeightPerLengthUnitFactor { get; set; }

        /// <summary>Length to weight unit description</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string LengthToWeightUnitDescription { get; set; }

        /// <summary>PieceLength</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceLength { get; set; }

        /// <summary>Piece facing</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceFacing { get; set; }

        /// <summary>Piece cut off</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceCutOff { get; set; }

        /// <summary>Weight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedWeight { get; set; }

        /// <summary>Weight unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PlannedWeightUnit { get; set; }

        /// <summary>Length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedLength { get; set; }

        /// <summary>Length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PlannedLengthUnit { get; set; }

        /// <summary>Whole bars</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? WholeBars { get; set; }

        /// <summary>Whole pieces per bars</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? WholePiecesPerBar { get; set; }

        /// <summary>Bars</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedBars { get; set; }

        /// <summary>Pieces per bar</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesPerBar { get; set; }

        /// <summary>Is calculated -  if Length = 0 and PieceFacing = 0 and PieceCutOff = 0 and PiecesPerMakeItem = 1 then false</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool IsCalculated { get; set; }
    }

    public class SheetCalculator : CalculatorBase
    {

        /// <summary>Sheet length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string SheetLengthUnit { get; set; }

        /// <summary>Sheet length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? SheetLength { get; set; }

        /// <summary>Sheet width</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? SheetWidth { get; set; }

        /// <summary>Margin</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? Margin { get; set; }

        /// <summary>Weight per area unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string WeightPerAreaUnit { get; set; }

        /// <summary>Weight per area unit factor</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? WeightPerAreaUnitFactor { get; set; }

        /// <summary>Length to weight unit description</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string AreaToWeightUnitDescription { get; set; }

        /// <summary>Piece length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceLength { get; set; }

        /// <summary>Piece width</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceWidth { get; set; }

        /// <summary>Allowance</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? Allowance { get; set; }

        /// <summary>Weight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedWeight { get; set; }

        /// <summary>Weight unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PlannedWeightUnit { get; set; }

        /// <summary>Area</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedArea { get; set; }

        /// <summary>Area unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PlannedAreaUnit { get; set; }

        /// <summary>Whole sheets</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? WholeSheets { get; set; }

        /// <summary>Whole pieces per sheet</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public int? WholePiecesPerSheet { get; set; }

        /// <summary>Sheets</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedSheets { get; set; }

        /// <summary>Pieces per sheet</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesPerSheet { get; set; }

        /// <summary>Is calculated -  if Length = 0 and Width = 0 and Allowance = 0 and PiecesPerMakeItem = 1 then false</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool IsCalculated { get; set; }
    }

    public class CoilWireLengthCalculator : CalculatorBase
    {
        /// <summary>Length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string LengthUnit { get; set; }

        /// <summary>Coil wire length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? CoilWireLength { get; set; }

        /// <summary>Coil wire width</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? CoilWireWidth { get; set; }

        /// <summary>Weight per length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string WeightPerLengthUnit { get; set; }

        /// <summary>Weight per length unit factor</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? WeightPerLengthUnitFactor { get; set; }

        /// <summary>Length to weight unit description</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string LengthToWeightUnitDescription { get; set; }

        /// <summary>Piece length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceLength { get; set; }

        /// <summary>Pieces across</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PiecesAcross { get; set; }

        /// <summary>Allowance</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? Allowance { get; set; }

        /// <summary>Weight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedWeight { get; set; }

        /// <summary>Weight unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PlannedWeightUnit { get; set; }

        /// <summary>Length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedLength { get; set; }

        /// <summary>Length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PlannedLengthUnit { get; set; }

        /// <summary>Is calculated -  Always true for CoilWireWeight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool IsCalculated { get; set; }
    }

    public class CoilWireWeightCalculator : CalculatorBase
    {
        /// <summary>Weight unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string WeightUnit { get; set; }

        /// <summary>Piece weight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceWeight { get; set; }

        /// <summary>Planned weight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PlannedWeight { get; set; }

        /// <summary>Weight unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string PlannedWeightUnit { get; set; }

        /// <summary>Is calculated -  Always true for CoilWireWeight</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool IsCalculated { get; set; }
    }

    public class VolumeCalculator : CalculatorBase
    {
        /// <summary>Length unit</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public string LengthUnit { get; set; }

        /// <summary>Length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? Length { get; set; }

        /// <summary>Width</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? Width { get; set; }

        /// <summary>Depth</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? Depth { get; set; }

        /// <summary>Piece length</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceLength { get; set; }

        /// <summary>Piece facing</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceFacing { get; set; }

        /// <summary>Piece cut off</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public double? PieceCutOff { get; set; }

        /// <summary>Is calculated -  if Length = 0 and PieceFacing = 0 and PieceCutOff = 0 and PiecesPerMakeItem = 1 then false</summary>
        [SDKFieldType(FieldType.ReadOnly)]
        public bool IsCalculated { get; set; }
    }
}
