import { Typography } from "antd";
import "./style.css";
import { Descriptions, Input, Radio,Button } from 'antd';
import UploadAvatar from "../../UploadAvatar";
const items = [
  {
    key: '1',
    label: 'Tên đăng nhập:',
    children: <Input/>,
  },
  {
    key: '2',
    label: 'Telephone',
    children: <Input/>,
  },
  {
    key: '3',
    label: 'Email',
    children: <Input/>,
  },
  {
    key: '4',
    label: 'Address',
    children: <Input/>,
  },
  {
    key: '5',
    label: 'Gender',
    children:   <Radio.Group name="gender" defaultValue={1}>
    <Radio value={1}>Nam</Radio>
    <Radio value={2}>Nữ</Radio>
  </Radio.Group>,
  },
  {
    key: '6',
    label: 'BirthDay',
    children:   <Input/>,
  },
  {
    key: '7',
    label: 'Avatar',
    children: <UploadAvatar/>,
  },
];

function ProfileForm() {
  return (
    <div>
      <Descriptions title="User Info" layout="vertical" items={items} />
      <div>
        <Button>Save</Button>
      </div>
      </div>
  );
}

export default ProfileForm;
