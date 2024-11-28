import { TimeIcon } from '@chakra-ui/icons';
import { Icon } from '@chakra-ui/react';
import {
  MdBarChart,
  MdPerson,
  MdHome,
  MdLock,
  MdOutlineShoppingCart,
  MdRoom,
  MdTimer,
} from 'react-icons/md';

// Admin Imports
// import MainDashboard from './pages/admin/default';
// import NFTMarketplace from './pages/admin/nft-marketplace';
// import Profile from './pages/admin/profile';
// import DataTables from './pages/admin/data-tables';
// import RTL from './pages/rtl/rtl-default';

// Auth Imports
// import SignInCentered from './pages/auth/sign-in';
import { IRoute } from 'types/navigation';

const routes: IRoute[] = [
  {
    name: 'Main Dashboard',
    layout: '/admin',
    path: '/default',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  // {
  //   name: 'NFT Marketplace',
  //   layout: '/admin',
  //   path: '/nft-marketplace',
  //   icon: (
  //     <Icon
  //       as={MdOutlineShoppingCart}
  //       width="20px"
  //       height="20px"
  //       color="inherit"
  //     />
  //   ),
  //   secondary: true,
  // },
  // {
  //   name: 'Data Tables',
  //   layout: '/admin',
  //   icon: <Icon as={MdBarChart} width="20px" height="20px" color="inherit" />,
  //   path: '/data-tables',
  // },
  // {
  //   name: 'Profile',
  //   layout: '/admin',
  //   path: '/profile',
  //   icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  // },
  {
     name: 'Sign In',
     layout: '/auth',
     path: '/sign-in',
     icon: <Icon as={MdLock} width="20px" height="20px" color="inherit" />,
  },
  // {
  //   name: 'RTL Admin',
  //   layout: '/rtl',
  //   path: '/rtl-default',
  //   icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  // },
  // {
  //   name: 'NFT Marketplace',
  //   layout: '/admin',
  //   path: '/doctor',
  //   icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  // },
  {
    name: 'Employee',
    layout: '/admin',
    path: '/employee',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Patient',
    layout: '/admin',
    path: '/patient',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Department',
    layout: '/admin',
    path: '/department',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Item',
    layout: '/admin',
    path: '/item',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Item Category',
    layout: '/admin',
    path: '/item-category',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Order',
    layout: '/admin',
    path: '/order',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'RoomType',
    layout: '/admin',
    path: '/roomType',
    icon: <Icon as={MdRoom} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Room',
    layout: '/admin',
    path: '/room',
    icon: <Icon as={MdRoom} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Nurse',
    layout: '/admin',
    path: '/nurse',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Doctor',
    layout: '/admin',
    path: '/doctor',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Pharmacist',
    layout: '/admin',
    path: '/pharmacist',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Schedule',
    layout: '/admin',
    path: '/schedule',
    icon: <Icon as={MdTimer} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Laboratoriest',
    layout: '/admin',
    path: '/laboratoriest',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Inventory',
    layout: '/admin',
    path: '/inventory',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Lab Test',
    layout: '/admin',
    path: '/labTest',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },

  {
    name: 'Specialization',
    layout: '/admin',
    path: '/specialization',
    icon: <Icon as={MdTimer} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'MedicalTestResult',
    layout: '/admin',
    path: '/medicalTestResult',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Scan Test',
    layout: '/admin',
    path: '/scanTest',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Medical Test Order',
    layout: '/admin',
    path: '/medicalTestOrder',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'TimeSlot',
    layout: '/admin',
    path: '/timeSlot',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Appointment',
    layout: '/admin',
    path: '/appointment',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Medicine',
    layout: '/admin',
    path: '/medicine',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
  {
    name: 'Prescription',
    layout: '/admin',
    path: '/prescription',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
  },
];

export default routes;
