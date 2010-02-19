SELECT rm, tglMasuk, p.Nama AS Nama, p.NO_ASURANSI AS SKP, ISNULL(d.NAMA, '-') AS Dokter, drg.kdUnit AS KdUnit, drg.urutMasuk AS UrutMasuk
FROM #DRG AS drg 
INNER JOIN dbo.KUNJUNGAN AS k 
 	ON k.TGL_MASUK = drg.tglMasuk 
	AND CONVERT(INT, REPLACE(LTRIM(REPLACE(REPLACE(k.KD_PASIEN, '-', ''), 0, ' ')), ' ', 0)) = drg.rm
	AND drg.kdUnit = k.KD_UNIT 
	AND drg.urutMasuk = k.URUT_MASUK
INNER JOIN dbo.PASIEN AS p 
	ON p.KD_PASIEN = k.KD_PASIEN
LEFT JOIN dbo.DOKTER AS d 
	ON k.KD_DOKTER = d.KD_DOKTER
ORDER BY urut ASC
