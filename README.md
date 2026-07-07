# Counter — Docker Workshop (เขียน Dockerfile เอง)

ระบบ 2 ชั้น (ไม่มี database): Angular (ปุ่ม Count / Discount) → .NET 8 API (นับเลข)

โจทย์: **เขียน Dockerfile เอง** ให้ backend และ frontend แล้วรันทั้งระบบด้วย Docker Compose

```
counter-workshop/
├── backend/            .NET 8 API (นับ +1 / -1) — * ยังไม่มี Dockerfile *
├── frontend/           Angular (ปุ่ม Count/Discount) — * ยังไม่มี Dockerfile *
├── เฉลย/               เฉลย: Dockerfile.backend / Dockerfile.frontend / docker-compose.yaml
└── README.md
```
> * `docker-compose.yaml` ที่โฟลเดอร์ราก ก็ **สร้างเอง** (copy จากสไลด์/เฉลย) *

## ต้องมี
- Docker Desktop (Engine running) · มีเน็ต (build ครั้งแรกโหลด image + npm/dotnet)

## ขั้นตอน
1. **แตก zip** → เปิดโปรเจคใน **VS Code** (สร้างไฟล์ Dockerfile ง่าย ไม่ติดปัญหา .txt)
2. **สร้าง Dockerfile ของ backend** — คลิกขวาโฟลเดอร์ `backend/` → New File → ตั้งชื่อ `Dockerfile` (ไม่มีนามสกุล) → copy เนื้อหาจากสไลด์ (เฉลย: `เฉลย/Dockerfile.backend`)
3. **สร้าง Dockerfile ของ frontend** — เช่นเดียวกันใน `frontend/` (เฉลย: `เฉลย/Dockerfile.frontend`)
4. **สร้าง `docker-compose.yaml`** ที่โฟลเดอร์ราก (counter-workshop/) — copy จากสไลด์ (เฉลย: `เฉลย/docker-compose.yaml`)
5. **รันทั้งระบบ** (Terminal ที่โฟลเดอร์ counter-workshop):
   ```bash
   docker stop api web                # หยุดของเก่า (จากขั้น build/run) กัน port ชน
   docker compose up -d --build
   ```
5. เปิด **http://localhost:4200** → กดปุ่ม **Count (+)** / **Discount (−)** → เลขเปลี่ยนตาม (มาจาก Backend)

ลอง API ตรง ๆ: **http://localhost:8080/api/count**

## ปิด
```bash
docker compose down
```

## จุดที่น่าสังเกต (สอนได้)
- ทุกครั้งที่กดปุ่ม → Frontend เรียก Backend → Backend นับแล้วส่งเลขกลับ (คนละ container)
- ตัวนับเก็บใน backend (หน่วยความจำ) — รีสตาร์ท container แล้วรีเซ็ตเป็น 0 (เพราะไม่มี database)
- แก้โค้ดแล้วต้อง `docker compose up -d --build` ใหม่ (image = snapshot)
