SELECT rm, tglMasuk, p.Nama AS Nama, p.NO_ASURANSI AS SKP, MAX(d.NAMA) AS Dokter 
FROM #DRG AS drg 
LEFT OUTER JOIN dbo.KUNJUNGAN AS k 
 	ON k.TGL_MASUK = drg.tglMasuk 
	AND REPLACE(LTRIM(REPLACE(REPLACE(k.KD_PASIEN, '-', ''), 0, ' ')), ' ', 0) = CONVERT(VARCHAR,drg.rm)
LEFT OUTER JOIN dbo.PASIEN AS p 
	ON p.KD_PASIEN = k.KD_PASIEN
LEFT OUTER JOIN dbo.DOKTER AS d 
	ON k.KD_DOKTER = d.KD_DOKTER
GROUP BY urut, rm, tglMasuk, p.Nama, p.NO_ASURANSI
ORDER BY urut ASC
