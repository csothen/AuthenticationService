import React from "react";

import Profile from "../Containers/Profile";

const ProfilePage = (props) => {
  return <Profile user={props.user} />;
};

export default ProfilePage;
