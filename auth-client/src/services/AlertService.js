import swal from "sweetalert";

export const alertSuccess = (title, text) => {
  return swal({
    title,
    text,
    icon: "success",
    timer: 750,
    buttons: false,
  });
};

export const alertError = (title, text) => {
  return swal({
    title,
    text,
    icon: "error",
    timer: 2000,
    buttons: false,
  });
};
