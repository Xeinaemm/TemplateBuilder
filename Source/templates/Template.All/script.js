import http from "k6/http";
import { check } from "k6";

export default function() {
    let res = http.get("https://localhost:44346/repositories/Xeinaemm");
    check(res, {
      "status was 200": (r) => r.status == 200
    });
};