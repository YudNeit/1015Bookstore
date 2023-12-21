import { MenuOutlined } from "@ant-design/icons";
import { Menu } from "antd";
import { useLocation, useNavigate } from "react-router-dom";
import React, { useEffect, useState } from "react";

function getItem(label, key, icon, children, type) {
  return {
    key,
    icon,
    children,
    label,
    type,
  };
}

const items = [
  getItem("", "", <MenuOutlined />, [
    getItem("Sách Thiếu Nhi", "1", null, [
      getItem("Đạo Đức và Kỹ Năng Sống", "12"),
      getItem("Truyện Cổ Tích", "truyen-co-tich"),
      getItem("Văn học Thiếu Nhi", "14"),
      getItem("Tô Màu - Luyện Chữ", "15"),
    ]),
    getItem("Sách Kinh Tế", "2", null, [
      getItem("Sách Doanh Nhân", "sach-doanh-nhan"),
      getItem("Sách Khởi Nghiệp", "17"),
      getItem("Sách Kinh Tế Học", "18"),
      getItem("Sách Kỹ Năng Làm Việc", "19"),
    ]),
    getItem("Sách Chính Trị", "3", null, [
      getItem("Luật - Văn bản Luật", "20"),
      getItem("Lý Luận Chính Trị", "21"),
    ]),
    getItem("Sách Tâm Lý", "sach-tam-ly"),
    getItem("Sách Y Học", "5"),
    getItem("Sách Văn Học", "6", null, [
      getItem("Light Novel", "22"),
      getItem("Sách Thơ", "23"),
      getItem("Tiểu Thuyết", "24"),
      getItem("Truyện Tranh", "25"),
    ]),
    getItem("Sách Lịch Sử", "7"),
    getItem("Sách Tôn Giáo - Tâm Linh", "8"),
    getItem("Sách Kỹ Năng Sống", "9", null, [
      getItem("Sách Hướng Nghiệp - Kỹ năng mềm", "26"),
      getItem("Sách Nghệ Thuật Sống Đẹp", "27"),
    ]),
    getItem("Sách Tham Khảo", "10", null, [
      getItem("Sách Tham Khảo cấp I", "28"),
      getItem("Sách Tham Khảo cấp II", "29"),
      getItem("Sách Tham Khảo cấp III", "30"),
      getItem("Sách Luyện Thi Đại Học", "31"),
    ]),
    getItem("Văn Phòng Phẩm", "11", null, [
      getItem("Bút Chì", "32"),
      getItem("Tẩy", "33"),
      getItem("Bút Bi", "34"),
      getItem("Thước", "35"),
      getItem("Kéo", "36"),
    ]),
  ]),
];

// const items1 = [
//   {
//     label: '',
//     key: 'Menu',
//     icon: <MenuOutlined />,
//     getItem('Navigation Two', 'sub2', <AppstoreOutlined />, [
//       getItem('Option 5', '5'),
//       getItem('Option 6', '6'),
//       getItem('Submenu', 'sub3', null, [getItem('Option 7', '7'), getItem('Option 8', '8')]),
//     ])}
// ];

const MenuSlide = ({ onMenuSelect }) => {
  const handleMenuClick = (selectedValue) => {
    onMenuSelect(selectedValue);
  };
  const location = useLocation();
  const [selectedKeys, setSelectedKeys] = useState("/");
  const navigate = useNavigate();

  useEffect(() => {
    const pathName = location.pathname;
    
    setSelectedKeys(pathName);
  }, [location.pathname]);

  return (
    <Menu
      className="SideMenuVertical"
      theme="light"
      selectedKeys={[selectedKeys]}
      style={{ width: 70, borderRight: "none" }}
      items={items}
      onClick={(item) => {
        handleMenuClick(item.key);
      }}
    />
  );
};
export default MenuSlide;
