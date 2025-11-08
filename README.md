# Amarta Binangun

Inilah permainan dua rupa adanya, beralas dunia wayang yang gemilang.
Maka kisah pun terbuka tentang kelima Pandawa yang budiman,
tatkala mereka mendirikan kerajaan Amarta,
lambang adil dan kasih dalam zaman nan purba.

---

*Kawruh pamutran ring jagat wayang.
Angalap carita Pandawa maṅrakit Amarta.
Praja ring dharma, sinurat ing suci.
Madhya antara mega lan swarga.*

---

## Konvensi

### Konvensi Penamaan C# untuk Unity

#### Tujuan

Dokumen ini menetapkan konvensi penamaan (*naming convention*) untuk seluruh elemen C# dalam proyek Unity. Tujuannya adalah untuk memastikan keterbacaan, konsistensi, dan kemudahan pemeliharaan kode di antara anggota tim pengembang.

---

#### Kata Modal

Kata-kata berikut HARUS ditafsirkan sebagaimana dijelaskan dalam [RFC 2119]:

* **HARUS** (*MUST*): persyaratan absolut yang wajib dipatuhi.
* **DILARANG** (*MUST NOT*): larangan absolut.
* **SEBAIKNYA** (*SHOULD*): rekomendasi kuat, DAPAT diabaikan hanya jika terdapat alasan teknis yang jelas.
* **SEBAIKNYA TIDAK** (*SHOULD NOT*): larangan kuat, DAPAT dilanggar hanya jika ada pertimbangan desain yang sah.
* **DAPAT** (*MAY*): opsional, sesuai konteks atau preferensi tim.

---

#### Konvensi Umum

* Penamaan **HARUS** konsisten di seluruh proyek.
* Bahasa penamaan **HARUS** menggunakan **bahasa Inggris**, kecuali untuk proyek lokal yang seluruh tim berbahasa Indonesia.
* Setiap nama **HARUS** deskriptif dan mencerminkan fungsi atau maknanya.
* Penyingkatan **DILARANG** digunakan kecuali umum dan jelas (mis. `UI`, `ID`, `HP`).
* Penamaan **DILARANG** mengandung angka kecuali untuk menunjukkan urutan (mis. `Player1`, `Enemy2` dalam konteks instans).

---

#### Struktur Proyek Unity

| Unsur Proyek             | Format     | Contoh                        | Keterangan                                              |
| ------------------------ | ---------- | ----------------------------- | ------------------------------------------------------- |
| Folder                   | PascalCase | `PlayerControllers`           | HARUS plural jika berisi banyak entitas sejenis         |
| Prefab                   | PascalCase | `EnemySoldier`, `MainCamera`  | Nama HARUS identik dengan nama kelas utama yang melekat |
| Scene                    | PascalCase | `MainMenu`, `Level01`         | DAPAT disertai nomor level                              |
| Script                   | PascalCase | `PlayerMovementController.cs` | HARUS cocok dengan nama kelas di dalamnya               |
| Material, Shader, Sprite | PascalCase | `MetalRough`, `PlayerAvatar`  | SEBAIKNYA mencerminkan kegunaan atau target objek      |

---

#### Elemen C#

- #### Namespace

    * HARUS mengikuti pola:

        ```
        CompanyName.ProjectName.Module
        ```

        contoh:
        `ErrilGames.SpaceRift.Player`

    * Namespace **DILARANG** menggunakan huruf kecil seluruhnya.

---

- #### Class & Struct

    * **HARUS** menggunakan **PascalCase**.
    * Nama **HARUS** merupakan kata benda atau konsep (noun).
    * Kelas yang ditujukan untuk MonoBehaviour **SEBAIKNYA** berakhiran dengan fungsinya (mis. `Controller`, `Manager`, `Presenter`).
    contoh:

        ```csharp
        public class PlayerMovementController : MonoBehaviour
        public struct DamageInfo
        ```

---

- #### Interface

    * **HARUS** diawali huruf `I`.
    contoh:

        ```csharp
        public interface IInteractable
        ```

---

- #### Enum

    * **HARUS** menggunakan **PascalCase** untuk nama enum dan nilai.
    contoh:

        ```csharp
        public enum WeaponType
        {
            Melee,
            Ranged,
            Magic
        }
        ```

---

- #### Field & Property

    * **Private field** HARUS menggunakan **camelCase** dengan garis bawah awalan (`_`).
    contoh: `_speed`, `_currentHealth`

    * **Public field** HARUS menggunakan **PascalCase**, namun SEBAIKNYA diubah menjadi *property*.

    * **Property** HARUS menggunakan **PascalCase**.
    contoh:

        ```csharp
        public float Speed { get; private set; }
        ```

    * Field yang di-*serialize* (dengan `[SerializeField]`) HARUS tetap private.
    contoh:

        ```csharp
        [SerializeField] private float _jumpForce;
        ```

---

- #### Method

    * **HARUS** menggunakan **PascalCase**.
    * Nama metode **HARUS** berupa kata kerja (verb) yang menjelaskan aksi.
    contoh:

        ```csharp
        void MovePlayer()
        void PlaySound()
        bool TryGetTarget()
        ```

---

- #### Parameter

    * **HARUS** menggunakan **camelCase** tanpa garis bawah.
    contoh:

        ```csharp
        void DealDamage(float damageAmount)
        ```

---

- #### Event dan Delegate

    * Nama event **HARUS** menggunakan **PascalCase** dan diawali kata kerja bentuk lampau atau hasil (mis. `On`, `Before`, `After`).
    contoh:

        ```csharp
        public event Action OnPlayerDeath;
        public event Action BeforeSceneLoad;
        ```

---

- #### Konstanta dan Static Readonly

    * **HARUS** menggunakan **PascalCase** tanpa garis bawah.
    contoh:

        ```csharp
        private const int MaxPlayerCount = 4;
        ```

---

- #### Variabel Lokal

    * **HARUS** menggunakan **camelCase**.
    contoh:

        ```csharp
        var playerSpeed = _speed * deltaTime;
        ```

---

### Folder dan Modul Kode

Struktur direktori HARUS mencerminkan pembagian tanggung jawab logis. Contoh:

```
.
└── Assets/
    └── _Dev/                               // tempat pengembang bekerja
        ├── Scenes/
        ├── Prefabs/
        ├── Art/
        └── Scripts/
            ├── Editor
            └── Runtime/
                ├── Common/
                │   ├── Singletons/
                │   ├── Sound/
                │   │   └── PlaySoundControllers/
                │   │       ├── PlaySoundOnCollision.cs
                │   │       └── ...
                │   ├── UI/
                │   └── ...
                ├── Core/
                │   ├── Entity/
                │   │   ├── Player/
                │   │   │   ├── PlayerMovementController.cs
                │   │   │   └── ...
                │   │   └── Enemy/
                │   ├── UI/
                │   │   ├── VictoryPanelPresenter.cs
                │   │   └── ...
                │   └── ...
                └── SOInstances/
                    ├── Variables/
                    │   └── PlayerHealth.cs
                    └── ...
```
>[Tree](https://tree.nathanfriend.com/?s=(%27optiLs!(%27fancyB~fullPath!false~trailingSlashB~rootDotB)~J(%27J%276Assets32_Dev3GScenes7Prefabs7Art7Scripts3*GEditor3*GRuntime06CommL02SingletLsK2F04F8T*4FOnCollisiLW2UIK56Core02Entity04N0*4NMovement8WGEnemyK2UI0GVictoryPanelPresentN9*556SOInstanceT2VariableT4NHealth9Q3%27)~vNsiL!%271%27)*%20%2003***G*63%5Cn4GPlay5Q06-%207%2F3G8CLtrollN9.cTB!trueFSoundG*2Jsource!K%2F0LonNerQ2...Ts0W9**5%01WTQNLKJGFB987654320*)

* Folder **Common** HARUS digunakan untuk skrip yang digunakan lintas modul.
* Folder **SEBAIKNYA** menggunakan bentuk singular jika dibentuk berdasarkan konsep atau sifat.
* Folder **SEBAIKNYA** menggunakan bentuk plural jika berupa koleksi (mis. `Scripts`, `Prefabs`).
    * Jika ragu, **SEBAIKNYA** menggunakan bentuk plural.
* Folder **SEBAIKNYA** memiliki nama yang singkat dan deskriptif.

---

### Atribut dan Anotasi Unity

* `[SerializeField]`, `[Header]`, `[Tooltip]`, dan `[Range]` **SEBAIKNYA** digunakan untuk memperjelas editor.
* Atribut **DILARANG** digunakan berlebihan atau tanpa alasan yang jelas.
* Komponen yang wajib ada **SEBAIKNYA** ditandai dengan `[RequireComponent(typeof(...))]`.

---

### Penutup

Kepatuhan terhadap konvensi ini **HARUS** dijaga melalui *code review* dan *linting tool*.
Pelanggaran kecil **DAPAT** diabaikan jika memiliki justifikasi teknis atau artistik yang terdokumentasi.
Tim pengembang **SEBAIKNYA** memperbarui dokumen ini seiring perubahan standar atau kebijakan proyek.
