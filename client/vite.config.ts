import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig({
  build: {
    outDir: "../api/wwwroot",
  },
  server: {
    port: 3000,
  },
  plugins: [react()],
  optimizeDeps: {
    exclude: ["js-big-decimal"],
  },
});
