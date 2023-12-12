//Layout
import UnlogLayout from "../Layouts/UnlogLayout";
import LogLayout from "../Layouts/LogLayout";
import DefaultLayout from "../Layouts/DefaultLayout";
import Layout404 from "../Layouts/Layout404";

//Pages
import CartPage from "../../pages/CartPage/CartPage";
import ConfirmEmail from "../../pages/ConfirmEmail/ConfirmEmail";
import ForgotPasswordPage from "../../pages/ForgotPassword/ForgotPassword";
import MainPage from "../../pages/MainPage/MainPage";
import ProductPage from "../../pages/ProductPage/ProductPage";
import SignIn from "../../pages/SignIn/SignIn";
import SignUp from "../../pages/SignUp/SignUp";
import ChangePasswordPage from "../../pages/ChangePasswordPage";
import UserPage from "../../pages/UserPage/UserPage";
import ProfilePage from "../../pages/ProflePage";
import Page404 from "../../pages/404Page";
import CheckoutPage from "../../pages/CheckoutPage";

const isLogin = true;

function DefineLayout() {
  return isLogin === false ? LogLayout : UnlogLayout;
}

//PublicRoutes
const publicRoutes = [
  { path: "/", component: MainPage, layout: DefineLayout() },
  { path: "/sign_in", component: SignIn, layout: LogLayout },
  { path: "/sign_up", component: SignUp, layout: LogLayout },
  { path: "/product_page", component: ProductPage, layout: DefineLayout() },
  {
    path: "/forgot_password",
    component: ForgotPasswordPage,
    layout: LogLayout,
  },
  { path: "/cart", component: CartPage },
  {
    path: "/change_password",
    component: ChangePasswordPage,
    layout: LogLayout,
  },
  { path: "/profile_page", component: ProfilePage, layout: DefineLayout() },
  { path: "/404_page", component: Page404, layout: Layout404 },
  { path: "/checkout", component: CheckoutPage, layout: DefineLayout() },
];
//PrivateRoutes
const privateRoutes = [
  { path: "/confirm_email", component: ConfirmEmail, layout: null },
  { path: "/user_page", component: UserPage, layout: UnlogLayout },
];

export { publicRoutes, privateRoutes };
