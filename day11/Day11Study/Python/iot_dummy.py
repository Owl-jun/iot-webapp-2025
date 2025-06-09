# IoT 더미데이터 생성 프로그램
# 현재일부터 10000일 전을 시작으로 하루에 데이터 100개씩

import mysql.connector
import random
from datetime import datetime, timedelta

# MySQL 연결설정
conn = mysql.connector.connect(
    host='localhost',
    database='smarthome',
    user='root',
    password='root'
)

cursor = conn.cursor()

# 입력값 파라미터
start_date = datetime(1998, 1, 20) # 10,000일전 기준일
records_per_day = 100
total_days = 10000

# 입력쿼리
insert_query = '''
INSERT INTO iot_datas (sensing_dt,loc_id,temp,humid)
VALUES (%s, %s, %s, %s)
'''

batch_size = 1000
batch = []

## 배치 리스트 생성
for day in range(total_days):
    date = start_date + timedelta(days=day)
    for i in range(records_per_day):
        timestamp = date + timedelta(minutes=15 * i)
        temp = round(random.uniform(19.0,28.0), 1)
        humid = round(random.uniform(30.0,75.0),2)
        batch.append((timestamp,'LIVING ROOM', temp, humid))

cursor.executemany(insert_query,batch)
conn.commit()
batch.clear()

cursor.close()
conn.close()
print('더미 데이터 생성 완료!')

