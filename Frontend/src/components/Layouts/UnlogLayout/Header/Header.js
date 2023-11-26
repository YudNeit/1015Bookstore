import classNames from "classnames/bind";
import images from "../../../../assets/images";
import MenuSlide from "../../../MenuSlide";
import SearchBar from "../../../SearchBar";
import CartButton from "../../../CartButton";
import { Button } from "antd";
const cx = classNames.bind();

console.log(images.logo);
function Header() {
  return (
    <header className={cx("wrapper")}>
      <div
        className={cx("inner")}
        style={{ display: "flex", marginBottom: 8, flexDirection: "row" }}
      >
        <div>
          <MenuSlide />
        </div>
        <div className={cx("logo")}>
          <img src={images.logo} alt="1015 BookStore" />
        </div>
        <div>
          <SearchBar />
        </div>
        <div>
          <CartButton />
        </div>
        <div>
          <Button
            style={{
              display: "inline",
              margin: "0px",
              height: "40px",
              width: "100%",
              border: "none",
              backgroundColor: "#30CF82",
              color: "white"
            }}
          >
            Đăng Nhập
          </Button>
        </div>
      </div>
    </header>
  );
}

export default Header;
