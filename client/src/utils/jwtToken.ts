import Jwt from "jsonwebtoken";
import { encode } from "base-64";
import storage from "./localStorage";

const secretKey = encode("secret");
const secretBytes = Buffer.from(secretKey, 'base64');

export const getUserToken = (): string | null => {
  let token = storage("getItem", "userToken");

  if (token) {
    try {
      Jwt.verify(token, secretBytes);
    } catch (err) {
      const decoded = Jwt.decode(token, {complete: true});
      const payload = decoded?.payload;

      token = Jwt.sign({
        sub: payload?.sub,
        roles: ["ROLE_USER"],
        iat: Math.floor(Date.now() / 1000) - 30
      }, secretBytes, {expiresIn: "10h"})

      storage("setItem", "userToken", token);
    }
  }
  return token;
}

export const getDevToken = (): string => {
  let token = storage("getItem", "devToken");

  if (token) {
    try {
      Jwt.verify(token, secretBytes);
    } catch (err) {
      token = null;
    }
  }

  if (!token) {
    token = Jwt.sign({
      sub: "Adi",
      roles: ["ROLE_DEV"],
      iat: Math.floor(Date.now() / 1000) - 30
    }, secretBytes, {expiresIn: "7d"})

    storage("setItem", "devToken", token);
  }

  return token;
}