# KDT_MES_EDU

작업장의 가동/비가동 이력관리

MES를 사용하는 이유
LOTTRACKING (LOT 추적)

1. 투입 LOT 생산LOT

## 저장프로시저 OUTPUT 값 가져오기
```
RSCODE = string.Empty;
RSMSG  = string.Empty;
SqlConnection Connect = new SqlConnection(sConn);
Connect.Open();
SqlCommand cmd = new SqlCommand();
cmd.Connection = Connect;
cmd.CommandType = CommandType.StoredProcedure;
RSMSG = Convert.ToString(cmd.Parameters["RS_MSG"].Value);
RSCODE = Convert.ToString(cmd.Parameters["RS_CODE"].Value);
```

## UPDATE OR INSERT의 SQL 로직 구현
```
UPDATE TABLE.A
IF(@@ROWCOUNT = 0)
BEGIN
INSERT INTO TABLE.B
END
```

##  하위 행의 정보가 같을 경우 (MERGE, 병합)
```
grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
grid1.DisplayLayout.Bands[0].Columns["WORKER"].MergedCellStyle = MergedCellStyle.Always;
grid1.DisplayLayout.Bands[0].Columns["PRODDATE"].MergedCellStyle = MergedCellStyle.Always;
grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
{
        CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("WORKER", "WORKCENTERCODE");
        e.Layout.Bands[0].Columns["WORKCENTERNAME"].MergedCellEvaluator = CM1;
        e.Layout.Bands[0].Columns["ITEMCODE"].MergedCellEvaluator = CM1;
        e.Layout.Bands[0].Columns["ITEMNAME"].MergedCellEvaluator = CM1;
        e.Layout.Bands[0].Columns["PRODDATE"].MergedCellEvaluator = CM1;
}
```

## 바코드 디자이너에 출력할 식별표 데이터 매핑
```
Report_LotBacodeFERT LotBacodeFERT = new Report_LotBacodeFERT();
Telerik.Reporting.ReportBook reportBook = new Telerik.Reporting.ReportBook();

LotBacodeFERT.DataSource = dttemp;

reportBook.Reports.Add(LotBacodeFERT);

ReportViewer Viewer = new ReportViewer(reportBook, 1);
Viewer.ShowDialog();
```

BOM 품목을 생산하는데 필요한 상/하위 리스트를 모아놓은 것(필수데이터) 완성품목 투입품목 1수량 단위 투입수량
LOT

# 구현화면
![BOM](https://github.com/roving324/KDT_MES_EDU/blob/master/IMG/BOM.PNG)
BOM

<br/>

![생산실적등록](https://github.com/roving324/KDT_MES_EDU/blob/master/IMG/%EC%83%9D%EC%82%B0%EC%8B%A4%EC%A0%81.PNG)
생산실적등록

<br/>

![작업자 일별 실적 조회](https://github.com/roving324/KDT_MES_EDU/blob/master/IMG/%EC%9E%91%EC%97%85%EC%9E%90%20%EC%9D%BC%EB%B3%84%20%EC%8B%A4%EC%A0%81.PNG)
작업자 일별 실적 조회

<br/>

# 프로세스 흐름도
![프로세스 흐름도](https://github.com/roving324/KDT_MES_EDU/blob/master/IMG/%ED%94%84%EB%A1%9C%EC%84%B8%EC%8A%A4%20%ED%9D%90%EB%A6%84%EB%8F%84.png)
