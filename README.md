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

## SQL 
```
 -- 5-3. 커서 시작 선언
OPEN CUR_TRADING_B
-- 5-4. 반복하는 행 별로 데이터가 담기는 변수.
FETCH NEXT FROM CUR_TRADING_B INTO @LS_LOTNO, @LS_ITEMCODE, @LF_SHIPQTY, @LI_SHIPSEQ, @LS_UNITCODE
-- 5-5 반복을 종료하는 시점
WHILE @@FETCH_STATUS = 0
BEGIN
  -- 5-6. 반복문을 수행하는 로직

  -- 6. 출하 실적 상세 데이터 등록
  INSERT INTO TB_TradingWM_B (PLANTCODE  , TRADINGNO                       , TRADINGSEQ       , LOTNO      , ITEMCODE,
                              TRADINGQTY , SHIPNO                          , SHIPSEQ          , MAKEDATE   , MAKER)
					  VALUES (@PLANTCODE , ISNULL(@LS_TRADINGNO,@TRADINGNO), @LI_TRADINGNO_SEQ, @LS_LOTNO  , @LS_ITEMCODE,
					          @LF_SHIPQTY, @SHIPNO                         , @LI_SHIPSEQ      , @LD_NOWDATE, @MAKER)
  SET @LI_TRADINGNO_SEQ = @LI_TRADINGNO_SEQ + 1

  -- 7. 제품 재고 삭제
  DELETE TB_StockWM
   WHERE PLANTCODE = @PLANTCODE
     AND LOTNO     = @LS_LOTNO

  -- 8. 제품 재고 출고 이력 등록
  DECLARE @LI_INOUTSEQ INT
  SELECT @LI_INOUTSEQ = ISNULL(MAX(INOUTSEQ),0) + 1
    FROM TB_StockWMrec WITH(NOLOCK)
   WHERE PLANTCODE    = @PLANTCODE
     AND RECDATE      = @LS_NOWDATE

  INSERT INTO TB_StockWMrec (PLANTCODE , RECDATE    , INOUTSEQ    , LOTNO       , ITEMCODE    , WHCODE ,
                             INOUTFLAG , INOUTCODE  , INOUTQTY    , UNITCODE    , MAKEDATE    , MAKER  )
					 VALUES (@PLANTCODE, @LS_NOWDATE, @LI_INOUTSEQ, @LS_LOTNO   , @LS_ITEMCODE, 'WH003',
					         'O'       , '60'       , @LF_SHIPQTY , @LS_UNITCODE, @LD_NOWDATE , @MAKER )


  FETCH NEXT FROM CUR_TRADING_B INTO @LS_LOTNO, @LS_ITEMCODE, @LF_SHIPQTY, @LI_SHIPSEQ, @LS_UNITCODE
END
-- 5-7. 반복문 종료
CLOSE CUR_TRADING_B
-- 5-8. 커서 선언 종료
DEALLOCATE CUR_TRADING_B
```

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
