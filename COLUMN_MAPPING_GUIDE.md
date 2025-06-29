# Hướng Dẫn Sử Dụng Công Cụ Ánh Xạ Cột

## Tổng Quan
Tính năng Công Cụ Ánh Xạ Cột đã được tích hợp vào ứng dụng Scan Box, cho phép bạn:
- Kết nối đến hai cơ sở dữ liệu khác nhau (DB1 và DB2)
- Ánh xạ cột từ bảng nguồn sang bảng đích
- Lưu/tải cấu hình ánh xạ từ file txt
- Xem trước và thực thi việc chuyển dữ liệu

## Cách Sử Dụng

### Bước 1: Mở Công Cụ Ánh Xạ Cột
1. Chạy ứng dụng Scan Box
2. Cửa sổ "Công Cụ Ánh Xạ Cột Cơ Sở Dữ Liệu" sẽ mở ra tự động

### Bước 2: Cấu Hình Kết Nối Cơ Sở Dữ Liệu

#### Cơ Sở Dữ Liệu Nguồn (DB1):
1. Nhập chuỗi kết nối vào textbox **txtDB1**
   ```
   Ví dụ: Data Source=10.80.1.46;Initial Catalog=PIMD;User ID=pim;Password=pimpass;MultipleActiveResultSets=True
   ```
2. Click nút **"Kiểm Tra"** để kiểm tra kết nối
3. Nếu kết nối thành công, dropdown **Bảng** sẽ được tải với danh sách bảng
4. Chọn bảng nguồn từ dropdown

#### Cơ Sở Dữ Liệu Đích (DB2):
1. Nhập chuỗi kết nối vào textbox **txtDB2**
   ```
   Ví dụ: Data Source=10.80.1.48;Initial Catalog=PIMV;User ID=pim;Password=pimpass;MultipleActiveResultSets=True
   ```
2. Click nút **"Kiểm Tra"** để kiểm tra kết nối
3. Chọn bảng đích từ dropdown

### Bước 3: Cấu Hình Ánh Xạ Cột
1. Sau khi chọn bảng nguồn, DataGridView sẽ hiển thị danh sách cột
2. Cho mỗi cột nguồn:
   - **Kích Hoạt**: Check/uncheck để bật/tắt ánh xạ
   - **Cột Nguồn**: Tên cột nguồn (chỉ đọc)
   - **Cột Đích**: Chọn cột đích từ dropdown
   - **Kiểu Dữ Liệu**: Kiểu dữ liệu của cột nguồn (chỉ đọc)

### Bước 4: Lưu Cấu Hình
1. Nhập tên cấu hình vào **"Tên Cấu Hình"**
2. Click **"Lưu Cấu Hình"** để lưu vào file txt
3. File sẽ được lưu trong thư mục `ColumnMappings/`

### Bước 5: Tải Cấu Hình Đã Lưu
- **Tải Cấu Hình**: Chọn từ danh sách cấu hình đã lưu
- **Tải Ánh Xạ**: Chọn file txt từ hệ thống file
- **Xóa Cấu Hình**: Xóa cấu hình đã lưu

### Bước 6: Thực Thi Ánh Xạ
1. Click **"Thực Thi Ánh Xạ"** để mở form thực thi
2. Trong form Thực Thi Ánh Xạ:
   - **Xem Trước**: Xem trước dữ liệu sẽ được chuyển
   - **Điều Kiện WHERE**: Thêm điều kiện lọc (tùy chọn)
   - **Giới Hạn Bản Ghi**: Giới hạn số bản ghi (mặc định 1000)
   - **Xóa dữ liệu bảng đích trước khi chèn**: Xóa dữ liệu cũ trước khi chèn mới
   - **Thực Thi Ánh Xạ**: Thực thi việc chuyển dữ liệu

## Cấu Trúc File Mapping

File mapping được lưu với định dạng:

```
# Column Mapping Configuration
# Configuration Name: Tên cấu hình
# Created: Ngày tạo
# Last Modified: Ngày sửa đổi cuối

[SOURCE_DATABASE]
ConnectionString=Connection string của DB nguồn
DatabaseName=Tên database nguồn
TableName=Tên bảng nguồn

[TARGET_DATABASE]
ConnectionString=Connection string của DB đích
DatabaseName=Tên database đích
TableName=Tên bảng đích

[COLUMN_MAPPINGS]
CotNguon1=CotDich1|DataType|True
CotNguon2=CotDich2|DataType|True
...
```

## Ví Dụ Connection String

### SQL Server với SQL Authentication:
```
Data Source=server_name;Initial Catalog=database_name;User ID=username;Password=password;MultipleActiveResultSets=True
```

### SQL Server với Windows Authentication:
```
Data Source=server_name;Initial Catalog=database_name;Integrated Security=True;MultipleActiveResultSets=True
```

### SQL Server với IP Address:
```
Data Source=192.168.1.100,1433;Initial Catalog=database_name;User ID=username;Password=password;MultipleActiveResultSets=True
```

## Lưu Ý Quan Trọng

1. **Backup dữ liệu**: Luôn backup dữ liệu trước khi thực thi mapping
2. **Kiểm tra data type**: Đảm bảo tương thích giữa cột nguồn và cột đích
3. **Quyền truy cập**: Đảm bảo có quyền SELECT trên bảng nguồn và INSERT trên bảng đích
4. **Network connectivity**: Kiểm tra kết nối mạng đến cả hai database
5. **Transaction safety**: Tool sử dụng transaction, sẽ rollback nếu có lỗi

## Troubleshooting

### Lỗi kết nối database:
- Kiểm tra connection string
- Kiểm tra network connectivity
- Kiểm tra username/password
- Kiểm tra firewall settings

### Lỗi không load được bảng:
- Kiểm tra quyền truy cập database
- Đảm bảo user có quyền SELECT trên INFORMATION_SCHEMA

### Lỗi mapping execution:
- Kiểm tra data type compatibility
- Kiểm tra constraint của bảng đích
- Kiểm tra quyền INSERT trên bảng đích
- Xem chi tiết lỗi trong message box

## Tính Năng Nâng Cao

1. **WHERE Clause**: Sử dụng để lọc dữ liệu nguồn
   ```sql
   Ví dụ: CreatedDate >= '2024-01-01' AND Status = 'Active'
   ```

2. **Record Limit**: Giới hạn số lượng record để test
3. **Truncate Option**: Xóa dữ liệu cũ trước khi insert mới
4. **Progress Tracking**: Theo dõi tiến trình thực thi
5. **Error Handling**: Rollback transaction nếu có lỗi

Chúc bạn sử dụng tool hiệu quả!
