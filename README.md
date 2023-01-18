# KDT_MES_EDU
MES 학습 중~

작업장의 가동/비가동 이력관리

MES를 사용하는 이유
LOTTRACKING (LOT 추적)

1. 투입 LOT 생산LOT

# 저장프로시저 OUTPUT 값 가져오기
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

# UPDATE 와 INSET의 SQL 로직 구현
```
UPDATE TABLE.A
   IF(@@ROWCOUNT = 0)
BEGIN
INSERT INTO TABLE.B
END
SET @RS_CODE = 'S'
```