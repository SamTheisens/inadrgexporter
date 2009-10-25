WITH Visits AS
(
SELECT 5303035 AS Kdrs, 2 AS Klsrs, CAST(REPLACE(p.KD_PASIEN, '-', '') AS INT) AS Norm, 3 AS Klsrawat, 0 AS Biaya,
row_number() OVER (ORDER BY p.KD_PASIEN DESC) AS Recid, 
1 as Jnsrawat, 
k.TGL_MASUK AS Tglmsk, k.TGL_KELUAR AS Tglklr, DATEDIFF(day,k.TGL_MASUK,ISNULL(k.TGL_KELUAR,k.TGL_MASUK)) AS Los, 
p.TGL_LAHIR AS Tgllhr, 
CASE WHEN DATEDIFF(year, p.TGL_LAHIR, 
GETDATE()) > 1 THEN DATEDIFF(year, p.TGL_LAHIR, GETDATE()) ELSE NULL END  AS UmurThn, 
CASE WHEN DATEDIFF(year, p.TGL_LAHIR, GETDATE()) < 1 THEN DATEDIFF(day, p.TGL_LAHIR, GETDATE()) END AS UmurHari,
CASE WHEN p.JENIS_KELAMIN = 1 THEN 1 ELSE 2 END AS JK, 1 AS CaraPlg, null as Berat, MAX(pen.Dutama) AS Dutama,
MAX(pen.D1) AS D1,MAX(pen.D2) AS D2,MAX(pen.D3) AS D3,MAX(pen.D4) AS D4,MAX(pen.D5) AS D5,MAX(pen.D6) AS D6,MAX(pen.D7) AS D7,MAX(pen.D8) AS D8,
NULL AS D9, NULL AS D10, NULL AS D11, NULL AS D12, NULL AS D13, NULL AS D14, NULL AS D15, NULL AS D16, NULL AS D17, NULL AS D18, NULL AS D19, NULL AS D20, NULL AS D21, NULL AS D22, NULL AS D23, NULL AS D24, NULL AS D25, NULL AS D26, NULL AS D27,  NULL AS D28, NULL AS D29,
NULL AS P1, NULL AS P2, NULL AS P3, NULL AS P4, NULL AS P5, NULL AS P6, NULL AS P7, NULL AS P8, NULL AS P9, NULL AS P10, 
NULL AS P11, NULL AS P12, NULL AS P13, NULL AS P14, NULL AS P15, NULL AS P16, NULL AS P17, NULL AS P18, NULL AS P19, NULL AS P20, 
NULL AS P21, NULL AS P22, NULL AS P23, NULL AS P24, NULL AS P25, NULL AS P26, NULL AS P27,  NULL AS P28, NULL AS P29, NULL AS Inadrg, NULL AS Tarif, NULL AS Deskripsi, 0 AS ALOS, count(*) as TOTAL
FROM      dbo.PASIEN AS p INNER JOIN
          dbo.KUNJUNGAN AS k ON p.KD_PASIEN = k.KD_PASIEN INNER JOIN
          dbo.CUSTOMER AS c ON k.KD_CUSTOMER = c.KD_CUSTOMER INNER JOIN
          dbo.TRANSAKSI AS t ON k.KD_PASIEN = t.KD_PASIEN AND k.TGL_MASUK = t.TGL_TRANSAKSI AND k.URUT_MASUK = t.URUT_MASUK AND k.KD_UNIT = t.KD_UNIT INNER JOIN
          dbo.RUJUKAN AS ru ON k.KD_RUJUKAN = ru.KD_RUJUKAN INNER JOIN
          dbo.UNIT AS un ON k.KD_UNIT = un.KD_UNIT LEFT OUTER JOIN
(SELECT md.*,pn.Penyakit ,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 1 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS Dutama,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 2 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D1,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 3 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D2,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 4 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D3,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 5 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D4,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 6 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D5,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 7 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D6,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 8 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D7,
CASE WHEN (RANK() OVER(PARTITION BY md.KD_PASIEN,md.TGL_MASUK,md.KD_UNIT,md.URUT_MASUK ORDER BY pn.KD_PENYAKIT ASC)) = 9 THEN REPLACE(pn.KD_PENYAKIT, '.', '') END AS D8
FROM Mr_Penyakit AS md INNER JOIN PENYAKIT AS pn ON pn.kd_penyakit = md.kd_penyakit) AS pen
ON pen.KD_PASIEN = p.KD_PASIEN AND pen.URUT_MASUK = k.URUT_MASUK AND pen.KD_UNIT = k.KD_UNIT AND pen.TGL_MASUK = k.TGL_MASUK
WHERE KD_BAGIAN IN (1,2,3) AND (k.TGL_MASUK BETWEEN '{0}' AND '{1}') AND k.KD_CUSTOMER = '{2}'
group by p.KD_PASIEN,k.TGL_MASUK,k.TGL_KELUAR,p.TGL_LAHIR,p.JENIS_KELAMIN)
SELECT * 
FROM Visits 
{3}
ORDER BY Tglmsk ASC
