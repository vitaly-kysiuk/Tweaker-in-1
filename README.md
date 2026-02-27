# Tweaker in 1 [beta] v0.12

# Windows System Optimizer

Застосунок для поліпшення, очищення та налаштування продуктивності ОС Windows. Проєкт демонструє роботу з системними компонентами та часткову реалізацію на низькому рівні з застосуванням WinAPI.

### Ключові можливості:
*   **Registry Optimization:** Автоматизація налаштувань системного реєстру (`HKCU`/`HKLM`) для підвищення відгуку інтерфейсу та вимкнення зайвої телеметрії.
*   **System Info & Monitoring:** Збір детальних даних про апаратне забезпечення через **WMI**.
*   **Startup Manager:** Керування автозавантаженням програм через аналіз гілок реєстру та системних папок.
*   **File System Cleaner:** Очищення тимчасових файлів, кешу та логів системи.
*   **System Commands:** Інтеграція з **CMD/PowerShell** через `Process.Start` для виконання адміністративних задач.

### Технології:
*   **C# / WinForms**
*   **Windows Registry API** (`Microsoft.Win32`)
*   **WinAPI (User32.dll, Shell32.dll)**
*   **WMI (System.Management)**

Застосунок має файл маніфесту, коли застосунок завантажується від імені **Адміністратора** для модифікації системних параметрів. Застосунок рекомендується використовувати з обережністю.

### Скріншоти застосунку:
<img width="549" height="400" alt="{39860E3A-9732-4EC2-930E-EB2B4D791B86}" src="https://github.com/user-attachments/assets/6f33e444-357f-4e8f-933a-43cbd3e27720" />
<img width="549" height="400" alt="{F4855606-733E-4406-9D9F-F7AFBF819B62}" src="https://github.com/user-attachments/assets/3a473fd0-63d3-4244-8762-62d20bddcc1a" />
<img width="549" height="400" alt="{292DC087-DE79-48B4-AE1C-C04092404B29}" src="https://github.com/user-attachments/assets/14423a2c-cf5b-40d8-9e06-2d8e595960be" />
<img width="549" height="400" alt="{CFBC74CD-EA66-4463-AC98-B08C8722C863}" src="https://github.com/user-attachments/assets/c16f931d-788a-4b2f-8af0-e3b787b87273" />


