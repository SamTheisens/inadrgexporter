SELECT rm, tglMasuk, p.Nama AS Nama, p.NO_ASURANSI AS SKP, MAX(d.NAMA) AS Dokter 
FROM #DRG AS drg 
LEFT OUTER JOIN dbo.KUNJUNGAN AS k 
 	ON k.TGL_MASUK = drg.tglMasuk 
	AND RIGHT('000000' + REPLACE(k.KD_PASIEN, '-', ''), 6) = drg.rm
LEFT OUTER JOIN dbo.PASIEN AS p 
	ON p.KD_PASIEN = k.KD_PASIEN
LEFT OUTER JOIN dbo.DOKTER AS d 
	ON k.KD_DOKTER = d.KD_DOKTER
GROUP BY urut, rm, tglMasuk, p.Nama, p.NO_ASURANSI
ORDER BY urut ASC
