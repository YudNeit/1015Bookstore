import { createContext, useContext, useState } from 'react';

const CartContext = createContext();

export const CartProvider = ({ children }) => {
  const [cartItems, setCartItems] = useState([]);

  const addToCart = (product) => {
    setCartItems((prevCartItems) => {
      // Check if the product is already in the cart
      const isProductInCart = prevCartItems.find((item) => item.id === product.id);

      if (isProductInCart) {
        // If the product is in the cart, update the quantity
        return prevCartItems.map((item) =>
          item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
        );
      } else {
        // If the product is not in the cart, add it with quantity 1
        return [...prevCartItems, { ...product, quantity: product.quantity }];
      }
    });
  };
  const updateCartItemQuantity = (itemId, newQuantity) => {
    setCartItems((prevCartItems) => {
      return prevCartItems.map((item) =>
        item.id === itemId ? { ...item, quantity: newQuantity } : item
      );
    });
  };

  const removeFromCart = (productId) => {
    setCartItems((prevCartItems) => prevCartItems.filter((item) => item.id !== productId));
  };

  return (
    <CartContext.Provider value={{ cartItems, addToCart, removeFromCart, updateCartItemQuantity }}>
      {children}
    </CartContext.Provider>
  );
};

export const useCart = () => useContext(CartContext);
