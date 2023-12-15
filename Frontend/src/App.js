import AppRoutes from "./components/Routes/Route";
import { CartProvider } from "./components/Context/CartContext";

function App() {
  return (
    <div className="App">
      <CartProvider>
        <AppRoutes />
      </CartProvider>
    </div>
  );
}

export default App;
