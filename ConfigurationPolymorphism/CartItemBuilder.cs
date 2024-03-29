﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationPolymorphism
{
    public class CartItemBuilder
    {
        private readonly string _name;
        private readonly decimal _price;

        private bool _withExtendedWarranty;
        private bool _withPromotion;

        public CartItemBuilder(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public CartItemBuilder WithExtendedWarranty()
        {
            _withExtendedWarranty = true;

            return this;
        }

        public CartItemBuilder WithPromotion()
        {
            _withPromotion = true;

            return this;
        }

        public ICartItem Build()
        {
            ICartItem cartItem = new CartItem(_name, _price);

            if (_withExtendedWarranty)
            {
                cartItem = new ExtendedWarrantyCartItem(cartItem);
            }

            if (_withPromotion)
            {
                cartItem = new PromotionCartItem(cartItem);
            }

            return cartItem;
        }
    }
}
