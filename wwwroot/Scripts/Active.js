const active = [
    {
        id: 1,
        name: 'Dashboard'
    },
    {
        id: 2,
        name: 'Contestant'
    },
    {
        id: 3,
        name: 'Voters'
    },
    {
        id: 4,
        name: 'Admin'
    },
    {
        id: 5,
        name: 'Election'
    },
    {
        id: 6,
        name: 'Position'
    },
    {
        id: 7,
        name: 'Account'
    },
    {
        id: 8,
        name: 'LogOut'
    },
];

const getactiveById = (id) => active.find(c => c.id == id);


const getAllActive = () => active;