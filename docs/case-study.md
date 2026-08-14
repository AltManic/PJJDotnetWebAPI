# Studi Kasus Release & Deployment
## Tugas Utama (Wajib)
- Menambahkan role baru yaitu role "Operator".
- Menerapkan otorisasi berbasis role Operator pada API UpdatePegawai (PUT api/Pegawai).
- Mendaftarkan pengguna baru dengan identitas masing-masing peserta (nama, NIP, email, jabatan)
- Menambahkan role Operator pada user peserta.
- Melakukan pengujian akses API UpdatePegawai menggunakan user peserta.
#### Pengumpulan Tugas:
- Screenshot API Get api/Account/manage-info pakai token user peserta (terdapat role Operator)
- Screenshot API GET api/Pegawai/{id} id pegawai yang diupdate

## Tambahan Nilai (Tidak Wajib)
- Menambah DeletedBy pada BaseIdentity
- Melakukan pengujian akses API DeleteAset menggunakan user peserta.
#### Pengumpulan Tugas:
- Screenshot API GET api/Aset dengan parameter includeDeleted=true (menampilkan asset yang dihapus)
