import classNames from "classnames/bind";
import images from "../../../../assets/images";
import MenuSlide from "../../../MenuSlide";
import SearchBar from "../../../SearchBar";
import CartButton from "../../../CartButton";
import { Button } from "antd";
import { UserOutlined } from "@ant-design/icons";

const cx = classNames.bind();

console.log(images.logo);
function Header() {
  return (
    <header className={cx("wrapper")}>
      <div
        className={cx("inner")}
        style={{ display: "flex", marginBottom: 8, flexDirection: "row" }}
      >
        <div className={cx("menu")}>
          <MenuSlide />
        </div>
        <div className={cx("logo")}>
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
          ></Button>
        </div>
      </div>
    </header>
  );
}

export default Header;
