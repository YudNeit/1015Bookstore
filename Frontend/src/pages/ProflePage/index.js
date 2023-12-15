import React, { useState, useEffect } from "react";
import { Descriptions, Input, Radio, Button, Space } from "antd";
import UploadAvatar from "../../components/UploadAvatar";

const items = [
  {
    key: "1",
    label: "Tên đăng nhập:",
    field: "username",
  },
  {
    key: "2",
    label: "Telephone",
    field: "telephone",
  },
  {
    key: "3",
    label: "Email",
    field: "email",
  },
  {
    key: "4",
    label: "Address",
    field: "address",
  },
  {
    key: "5",
    label: "Gender",
    field: "gender",
    type: "radio",
  },
  {
    key: "6",
    label: "BirthDay",
    field: "birthday",
  },
  {
    key: "7",
    label: "Avatar",
    field: "avatar",
  },
];

function ProfilePage() {
  const [userData, setUserData] = useState({
    username: "",
    telephone: "",
    email: "",
    address: "",
    gender: "",
    birthday: "",
    avatar: "",
  });
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    // Fetch user data from your API or any data source
    // and set it to the state
    const fetchedUserData = {
      username: "JohnDoe",
      telephone: "123456789",
      email: "john.doe@example.com",
      address: "123 Main Street, City",
      gender: "Male",
      birthday: "1990-01-01",
      avatar: "path/to/avatar.jpg",
    };

    setUserData(fetchedUserData);
  }, []); // Empty dependency array means this effect runs once on component mount

  const handleChange = (field, value) => {
    setUserData((prevUserData) => ({
      ...prevUserData,
      [field]: value,
    }));
  };

  const handleSave = () => {
    // Implement logic to save updated user data
    console.log("Updated user data:", userData);
    setIsEditing(false); // Disable editing mode after saving
  };

  const handleEdit = () => {
    setIsEditing(true);
  };

  return (
    <div>
      <Descriptions title="User Info" layout="vertical">
        {items.map((item) => (
          <Descriptions.Item key={item.key} label={item.label}>
            {item.field === "avatar" ? (
              <UploadAvatar
                disabled={!isEditing}
                onChange={(value) => handleChange(item.field, value)}
              />
            ) : item.type === "radio" ? (
              <Radio.Group
                disabled={!isEditing}
                value={userData[item.field]}
                onChange={(e) => handleChange(item.field, e.target.value)}
              >
                <Radio value="Male">Nam</Radio>
                <Radio value="Female">Nữ</Radio>
              </Radio.Group>
            ) : (
              <Input
                disabled={!isEditing}
                value={userData[item.field]}
                onChange={(e) => handleChange(item.field, e.target.value)}
              />
            )}
          </Descriptions.Item>
        ))}
      </Descriptions>
      <div style={{ marginTop: "20px" }}>
        {isEditing ? (
          <Space>
            <Button type="primary" onClick={handleSave}>
              Save
            </Button>
            <Button onClick={() => setIsEditing(false)}>Cancel</Button>
          </Space>
        ) : (
          <Button type="primary" onClick={handleEdit}>
            Chỉnh Sửa
          </Button>
        )}
      </div>
    </div>
  );
}

export default ProfilePage;
