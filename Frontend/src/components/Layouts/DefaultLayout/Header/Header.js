import classNames from "classnames/bind";
import images from "../../../../assets/images";
import MenuSlide from "../../../MenuSlide";
import SearchBar from "../../../SearchBar";
import CartButton from "../../../CartButton";
import { Button } from "antd";
import { UserOutlined } from "@ant-design/icons";
import { useNavigate } from "react-router-dom";

const cx = classNames.bind();

function Header() {
  const navigate = useNavigate();
  return (
    <header className={cx("wrapper")}>
      <div
        className={cx("inner")}
        style={{ display: "flex", marginBottom: 10, flexDirection: "row" }}
      >
        <div className={cx("menu")}>
          <MenuSlide />
        </div>
        <div className={cx("logo")}
        onClick={() => {
          navigate("/");
        }}>
          <img src={images.logo} alt="1015 BookStore" />
        </div>
        <div className={cx("search_bar")}>
          <SearchBar />
        </div>
        <div className={cx("cart_button")}>
          <CartButton />
        </div>
        <div>
          <Button
            icon={<UserOutlined />}
            style={{
              display: "inline",
              margin: "20px",
              height: "40px",
              width: "100%",
              border: "none",
            }}
            onClick={() => {
              navigate("/profile_page");
            }}
          ></Button>
        </div>
      </div>
    </header>
  );
}

export default Header;
